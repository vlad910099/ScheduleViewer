using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Domain.Models
{
    public class Class
    {
        public string ScheduleName { get; }
        public uint WeekDay { get; }
        public uint Number { get; }
        public WeekType WeekType { get; }
        public string Subject { get; }
        public Group Group { get; }
        public Teacher Teacher { get; }
        public string Room { get; }

        public Class(string scheduleName,
                     uint weekDay,
                     uint number,
                     WeekType weekType,
                     string subject,
                     Group group,
                     Teacher teacher,
                     string room)
        {
            if (string.IsNullOrEmpty(scheduleName))
            {
                throw new ArgumentNullException(nameof(scheduleName));
            }

            if (string.IsNullOrEmpty(subject))
            {
                throw new ArgumentNullException(nameof(subject));
            }

            ScheduleName = scheduleName;
            WeekDay = weekDay;
            Number = number;
            WeekType = weekType;
            Subject = subject;
            Group = group ?? throw new ArgumentNullException(nameof(group));
            Teacher = teacher;
            Room = room;
        }
    }
}
