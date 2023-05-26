using Domain.Enums;
using Domain.Models;
using Main.Parsers;
using NPOI.SS.Formula.Functions;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Threading.Tasks;
using System.Xml;
using UDUNT_TimeTable;
using UDUNT_TimeTable.Services;
using Xamarin.Forms.Shapes;

namespace Main.Services
{
    public class SiteScheduleProvider : IScheduleProvider
    {
        private readonly IEnumerable<IFileScheduleParser> fileScheduleParsers;
        private static string httpContext = "https://ust.edu.ua/student/lessons_schedule";
        private static ConcurrentDictionary<Uri, byte[]> fileCache = new ConcurrentDictionary<Uri, byte[]>();

        private static ScheduleInfo[] siteSchedulesCache;
        private static readonly ConcurrentDictionary<string, ScheduleInfo> scheduleInfoCache = new ConcurrentDictionary<string, ScheduleInfo>();
        private static readonly ConcurrentDictionary<string, Schedules> scheduleCache = new ConcurrentDictionary<string, Schedules>();

        public SiteScheduleProvider(IEnumerable<IFileScheduleParser> fileScheduleParsers)
        {
            this.fileScheduleParsers = fileScheduleParsers;
        }

        public Task<ScheduleInfo[]> GetSchedules()
        {

            try
            {
                Dictionary<string, string> result = new Dictionary<string, string>();

                HttpClientHandler hdl = new HttpClientHandler { AllowAutoRedirect = false, AutomaticDecompression = System.Net.DecompressionMethods.Deflate | System.Net.DecompressionMethods.GZip | System.Net.DecompressionMethods.None };
                var clnt = new HttpClient(hdl);
                HttpResponseMessage resp = clnt.GetAsync(httpContext).Result;
                        
                if (resp.IsSuccessStatusCode)
                {
                    var html = resp.Content.ReadAsStringAsync().Result;
                    if (!string.IsNullOrEmpty(html))
                    {
                        HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
                        doc.LoadHtml(html);

                        var rows = doc.DocumentNode.SelectNodes(".//div[@class='col-xs-12']//div[@class='content']");
                        if (rows != null && rows.Count > 0)
                        {
                            foreach (var row in rows)
                            {
                                var hrefs = row.SelectNodes(".//a");
                                if (hrefs != null && hrefs.Count > 0)
                                {
                                    foreach (var item in hrefs)
                                    {
                                        string a = item.GetAttributeValue("href", "");
                                        if (a != null)
                                            result[item.InnerText.Replace("&nbsp;", " ")] = a.Replace("////", "https://");
                                    }

                                }
                            }
                            return Task.FromResult(SchedulesInfo(result));
                        }
                        else
                        {
                            Console.WriteLine("No tables");
                        }
                    }
                }
               
            }
            catch (Exception ex) { 
                    
            }

            return null;

            throw new NotImplementedException();
        }

        public ScheduleInfo[] SchedulesInfo(Dictionary<string, string> result)
        {
            ScheduleInfo[] nameSchedules = new ScheduleInfo[result.Count];
            int i = 0;
            foreach (var item in result)
            {
                if (i < result.Count)
                    nameSchedules[i] = new ScheduleInfo(item.Key, GetYear(item.Key), new Uri(item.Value), null);
                i++;
            }
            return nameSchedules;
        }


        public async Task<ScheduleInfo> GetScheduleInfo(ScheduleInfo initialScheduleInfo)
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
            var result = new ScheduleInfo(initialScheduleInfo.Name, initialScheduleInfo.Year, initialScheduleInfo.Url, fileData);

            scheduleInfoCache.TryAdd(initialScheduleInfo.Name, result);

            return result;
        }
        public async Task<Schedules> Get(ScheduleInfo scheduleInfo)
        {
            if (scheduleCache.TryGetValue(scheduleInfo.Name, out var scheduleFromCache))
            {
                return scheduleFromCache;
            }
            var result = new Schedules(scheduleInfo.Name, scheduleInfo.Year, scheduleInfo.Url, scheduleInfo.Checksum);
            if (string.IsNullOrEmpty(scheduleInfo.Checksum.ToString()))
            {
                return result;
            }
            var fileData = await GetFileData(scheduleInfo.Url);
            if (fileData == null)
            {
                return result;
            }
            foreach (var fileScheduleParser in fileScheduleParsers)
            {
                FileType fileType;
                if (scheduleInfo.Url.ToString().Contains(".xls"))
                    fileType = FileType.Xls;
                else if (scheduleInfo.Url.ToString().Contains(".xlsx")) 
                    fileType = FileType.Xlsx;
                else fileType = FileType.None;

                var parseResult = await fileScheduleParser.Parse(scheduleInfo.Checksum, fileType, scheduleInfo.Name);

                if (!string.IsNullOrEmpty(parseResult.ErrorMessage))
                {
                    return result;
                }

                if (!parseResult.NotSupported)
                {
                    var scheduleResult = new Schedules(scheduleInfo.Name, scheduleInfo.Year, scheduleInfo.Url, scheduleInfo.Checksum, parseResult.Classes);
                    scheduleCache.TryAdd(scheduleInfo.Name, scheduleResult);
                    return scheduleResult;
                }
            }

            return result;
        }

        private string? GetYear(string name)
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
    }
}
