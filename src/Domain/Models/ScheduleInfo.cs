using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public class ScheduleInfo
    {
        public string Name { get; }
        public DateTime CreatedDateTime { get; }

        public ScheduleInfo(string name, DateTime createdDateTime)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException(nameof(name));
            }

            Name = name;
            CreatedDateTime = createdDateTime;
        }
    }
}
