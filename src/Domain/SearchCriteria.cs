using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class SearchCriteria
    {
        public string ScheduleName { get; }
        public string? TeacherName { get; }
        public string? GroupName { get; }

        public SearchCriteria(string scheduleName, string? teacherName, string? groupName)
        {
            if (string.IsNullOrEmpty(scheduleName))
            {
                throw new ArgumentNullException(nameof(scheduleName));
            }

            ScheduleName = scheduleName;
            TeacherName = teacherName;
            GroupName = groupName;
        }
    }
}
