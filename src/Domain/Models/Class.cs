 using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Text.RegularExpressions;

namespace Domain.Models
{
    public class Class
    {
        public string ScheduleName { get; set; }
        public int WeekDay { get; set; }
        public int Number { get; set; }
        public WeekType WeekType { get; set; }
        public string Subject { get; set; }
        public Group Group { get; set; }
        public Teacher Teacher { get; set; }
        public string Room { get; set; }
        public SubType SubType { get; set; }
        public DateTime Date { get; set; }

        public Class(string scheduleName,
                     int weekDay,
                     int number,
                     WeekType weekType,
                     string subject,
                     Group group,
                     Teacher teacher,
                     string room,
                     SubType subType,
                     DateTime date
            )
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
            SubType = subType;
            Date = date;
        }

        public Class()
        {

        }

        public override string ToString()
        {
            return $"{Subject} {Group.Name}";
        }
    }
}
