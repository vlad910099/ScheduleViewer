using Domain.Enums;
using System;

namespace Domain.Models
{
    public class Class
    {
        public string Subject { get; }
        public Group Group { get; }
        public Teacher Teacher { get; }
        public string Auditory { get; }
        public int WeekDay { get; }
        public int Number { get; }
        public WeekType WeekType { get; }
        public ClassSubType SubType { get; }
        public DateTime? Date { get; }

        public Class(string subject, Group group, Teacher teacher, string auditory, int weekDay, int number, WeekType weekType, ClassSubType subType, DateTime? date)
        {
            if (string.IsNullOrEmpty(subject))
            {
                throw new ArgumentNullException(nameof(subject));
            }

            if (subType != ClassSubType.Other && date == null)
            {
                throw new ArgumentNullException(nameof(date));
            }

            Group = group ?? throw new ArgumentNullException(nameof(group));
            WeekDay = weekDay;
            Number = number;
            WeekType = weekType;
            Subject = subject;
            Teacher = teacher;
            Auditory = auditory;
            SubType = subType;
            Date = date;
        }

        public Class(string subject, Group group, Teacher teacher, string auditory, int weekDay, int number, WeekType weekType)
            : this(subject, group, teacher, auditory, weekDay, number, weekType, ClassSubType.Other, null)
        { }

        public override string ToString()
        {
            return $"{Subject} {Group.Name}";
        }
    }
}