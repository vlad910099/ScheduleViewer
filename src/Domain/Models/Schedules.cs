using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Models
{
    public class Schedules
    {
        private List<Class> classes;

        public string Name { get; }
        public string Year { get; }
        public Uri Url { get; }
        public byte[] Checksum { get; }
        public IEnumerable<Class> Classes => classes;

        public Schedules(string name, string year, Uri url, byte[] checksum, IEnumerable<Class>? classes = null)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException(nameof(name));
            }

            this.classes = classes?.ToList() ?? new List<Class>();

            Name = name;
            Year = year;
            Checksum = checksum;
            Url = url;
        }

        public void AddClasses(IEnumerable<Class> classes)
        {
            if (classes != null && classes.Any())
            {
                this.classes.AddRange(classes);
            }
        }
    }
}
