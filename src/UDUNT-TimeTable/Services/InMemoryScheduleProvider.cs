using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UDUNT_TimeTable.Services;

namespace UDUNT_TimeTable.Services
{
    public class InMemoryScheduleProvider : IScheduleProvider
    {
        private static readonly List<ScheduleInfo> schedules = new List<ScheduleInfo>()
            {
                new ScheduleInfo("Розклад занять на 2 семестр 2022/23 н.р.", DateTime.Now),
                new ScheduleInfo("Розклад занять на 1 семестр 2022/23 н.р.", DateTime.Now.AddDays(-30))
            };

        public Task<Schedule> Get(string name)
        {
            var info = schedules.First(s => s.Name == name);
            var schedule = new Schedule(name, info.CreatedDateTime);
            var classes = new List<Class>();

            schedule.AddClasses(classes);

            return Task.FromResult(schedule);
        }

        public Task<string[]> GetAvailableScheduleNames()
        {
            return Task.FromResult(schedules.Select(s => s.Name).ToArray());
        }

        public Task<ScheduleInfo> GetInfo(string name)
        {
            var info = schedules.First(s => s.Name == name);
            return Task.FromResult(info);
        }
    }
}
