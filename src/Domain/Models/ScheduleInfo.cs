using System;

namespace Domain.Models
{
    public class ScheduleInfo
    {
        public string Name { get; }
        public string Year { get; }
        public Uri Url { get; }
        public string Checksum { get; }

        public ScheduleInfo(string name, string year, Uri url, string checksum)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException(nameof(name));
            }

            Name = name;
            Year = year;
            Url = url;
            Checksum = checksum;
        }
    }
}