using System;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Models
{
    public class Schedule
    {
        public ScheduleInfo Info { get; }
        public IEnumerable<Class> Classes { get; }

        public Schedule(ScheduleInfo info, IEnumerable<Class> classes)
        {
            if (info == null)
            {
                throw new ArgumentNullException(nameof(info));
            }

            Classes = classes?.ToList() ?? new List<Class>();
            Info = info;
        }
    }
}