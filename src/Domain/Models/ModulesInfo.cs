using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public class ModulesInfo : Class
    {
        public SubType SubType { get; set; }
        public DateTime Date { get; set; }
        public string Time { get; set; }
        public ModulesInfo( string scheduleName,
                        string subject,
                        Group group,
                        Teacher teacher,
                        string room,
                        SubType subType,
                        DateTime date,
                        string time)
        {
            ScheduleName = scheduleName;
            Subject = subject;
            Group = group ?? throw new ArgumentNullException(nameof(group));
            Teacher = teacher;
            Room = room;
            SubType = subType;
            Date = date;
            Time = time;
        }

        public ModulesInfo ()
        {

        }
        public override string ToString()
        {
            return $"{Subject} {Group.Name}";
        }
    }
}

