using Core.Parsers;
using Domain.Models;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace Core.Services
{
    public class SiteScheduleProvider : IScheduleProvider
    {
        private readonly IEnumerable<IFileScheduleParser> fileScheduleParsers;
        private static readonly Uri siteUri = new Uri("https://ust.edu.ua/student/lessons_schedule");

        #region Cache

        private static readonly ConcurrentDictionary<Uri, byte[]> fileCache = new ConcurrentDictionary<Uri, byte[]>();
        private static ScheduleInfo[] siteSchedulesCache;
        private static readonly ConcurrentDictionary<string, ScheduleInfo> scheduleInfoCache = new ConcurrentDictionary<string, ScheduleInfo>();
        private static readonly ConcurrentDictionary<string, Schedule> scheduleCache = new ConcurrentDictionary<string, Schedule>();

        #endregion Cache

        public SiteScheduleProvider(IEnumerable<IFileScheduleParser> fileScheduleParsers)
        {
            this.fileScheduleParsers = fileScheduleParsers;
        }

        public async Task<ScheduleInfo[]> GetScheduleInfos()
        {
            if (siteSchedulesCache != null)
            {
                return siteSchedulesCache;
            }

            var result = await GetInfos();

            if (result.Any())
            {
                siteSchedulesCache = result;
            }

            return result;
        }

        public async Task<ScheduleInfo> ExtendScheduleInfo(ScheduleInfo initialScheduleInfo)
        {
            if (scheduleInfoCache.TryGetValue(initialScheduleInfo.Name, out var scheduleInfo))
            {
                return scheduleInfo;
            }

            if (initialScheduleInfo.Url == null)
            {
                return initialScheduleInfo;
            }

            var fileData = await GetFileData(initialScheduleInfo.Url);

            if (fileData == null)
            {
                return initialScheduleInfo;
            }

            var checksum = GetCheckSum(fileData);
            var result = new ScheduleInfo(initialScheduleInfo.Name, initialScheduleInfo.Year, initialScheduleInfo.Url, checksum);

            scheduleInfoCache.TryAdd(initialScheduleInfo.Name, result);

            return result;
        }

        public async Task<Schedule> Get(ScheduleInfo scheduleInfo)
        {
            if (scheduleCache.TryGetValue(scheduleInfo.Name, out var scheduleFromCache))
            {
                return scheduleFromCache;
            }

            var result = new Schedule(scheduleInfo, null);

            if (string.IsNullOrEmpty(scheduleInfo.Checksum) || scheduleInfo.Url == null)
            {
                return result;
            }

            var fileData = await GetFileData(scheduleInfo.Url);
            if (fileData?.Any() != true)
            {
                return result;
            }

            var fileType = GetFileType(scheduleInfo.Url.ToString());

            foreach (var fileScheduleParser in fileScheduleParsers)
            {
                var parseResult = await fileScheduleParser.Parse(fileData, fileType, scheduleInfo.Name);

                if (!string.IsNullOrEmpty(parseResult.ErrorMessage))
                {
                    return result;
                }

                if (!parseResult.NotSupported)
                {
                    var scheduleResult = new Schedule(scheduleInfo, parseResult.Classes);
                    scheduleCache.TryAdd(scheduleInfo.Name, scheduleResult);

                    return scheduleResult;
                }
            }

            return result;
        }

        private static FileType GetFileType(string url)
        {
            if (url.EndsWith(".xls"))
            {
                return FileType.Xls;
            }

            if (url.EndsWith(".xlsx"))
            {
                return FileType.Xlsx;
            }

            return FileType.NotSupported;
        }

        private string GetYear(string name)
        {
            var nameParts = name.Split('/');

            if (nameParts.Length == 2)
            {
                var yearFirstPart = nameParts[0].Split(' ').LastOrDefault();
                var yearSecondPart = nameParts[1].Split(' ').FirstOrDefault();

                if (yearFirstPart != null && yearSecondPart != null)
                {
                    return $"{yearFirstPart}/{yearSecondPart}";
                }
            }

            return null;
        }

        private async Task<byte[]> GetFileData(Uri uri)
        {
            if (fileCache.TryGetValue(uri, out var data))
            {
                return data;
            }

            try
            {
                using (var client = new HttpClient())
                {
                    var response = await client.GetAsync(uri);
                    if (response.IsSuccessStatusCode)
                    {
                        var result = await response.Content.ReadAsByteArrayAsync();
                        fileCache.TryAdd(uri, result);

                        return result;
                    }
                }
            }
            catch (Exception)
            {
            }

            return null;
        }

        private string GetCheckSum(byte[] data)
        {
            var md5 = MD5.Create();
            var hash = md5.ComputeHash(data);

            return BitConverter.ToString(hash).Replace("-", "");
        }

        private async Task<ScheduleInfo[]> GetInfos()
        {
            try
            {
                var handler = new HttpClientHandler
                {
                    AllowAutoRedirect = false,
                    AutomaticDecompression = System.Net.DecompressionMethods.Deflate | System.Net.DecompressionMethods.GZip | System.Net.DecompressionMethods.None
                };

                handler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

                using (var client = new HttpClient(handler))
                {

                    var response = await client.GetAsync(siteUri);

                    if (!response.IsSuccessStatusCode)
                    {
                        return Array.Empty<ScheduleInfo>();
                    }

                    var html = await response.Content.ReadAsStringAsync();

                    if (string.IsNullOrEmpty(html))
                    {
                        return Array.Empty<ScheduleInfo>();
                    }

                    var parseResult = ParseSiteHtml(html);
                    var infos = new List<ScheduleInfo>();

                    foreach (var item in parseResult)
                    {
                        var info = new ScheduleInfo(item.Key, GetYear(item.Key), new Uri(item.Value), null);
                        infos.Add(info);
                    }

                    return infos.ToArray();
                }
            }
            catch (Exception e)
            {
                return Array.Empty<ScheduleInfo>();
            }
        }

        private IDictionary<string, string> ParseSiteHtml(string html)
        {
            var result = new Dictionary<string, string>();
            var doc = new HtmlAgilityPack.HtmlDocument();

            doc.LoadHtml(html);

            var nodes = doc.DocumentNode.SelectNodes(".//div[@class='col-xs-12']//div[@class='content']");

            if (nodes?.Any() != true)
            {
                return result;
            }

            foreach (var node in nodes)
            {
                var linkNodes = node.SelectNodes(".//a");

                if (linkNodes?.Any() == true)
                {
                    foreach (var linkNode in linkNodes)
                    {
                        var href = linkNode.GetAttributeValue("href", "");
                        if (!string.IsNullOrEmpty(href))
                        {
                            var scheduleName = linkNode.InnerText.Replace("&nbsp;", " ");
                            string scheduleUrl;
                            if (!href.StartsWith("http"))
                            {
                                if (href.Contains("////"))
                                    scheduleUrl = href.Replace("////", "https://");
                                else
                                    scheduleUrl = "https:" + href;
                            }
                            else
                            {
                                scheduleUrl = href;
                            }

                            if (scheduleUrl.EndsWith(".xls") || scheduleUrl.EndsWith(".xlsx"))
                            {
                                result.Add(scheduleName, scheduleUrl);
                            }
                        }
                    }
                }
            }
            return result;
        }
    }
}