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
        public DateTime CreatedDateTime { get; }
        public IEnumerable<Class> Classes => classes;

        public Schedules(string name, DateTime createdDateTime, IEnumerable<Class>? classes = null)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException(nameof(name));
            }

            this.classes = classes?.ToList() ?? new List<Class>();
            Name = name;
            CreatedDateTime = createdDateTime;
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
