using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public class ScheduleInfo
    {
        public string Name { get; }
        public string Year { get; }
        public Uri Url { get; }
        public byte[]? Checksum { get; }
        public DateTime? CreatedDateTime { get; }

        public ScheduleInfo(string name, string year, Uri url, byte[]? checksum)
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
