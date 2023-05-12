using Domain.Interfaces;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UDUNT_TimeTable.Persistence.InMemory
{
    public class InMemoryScheduleRepository : IScheduleRepository
    {
        private static readonly List<ScheduleInfo> schedules = new List<ScheduleInfo>()
        {
            new ScheduleInfo("Розклад занять на 2 семестр 2022/23 н.р.", DateTime.Now),
            new ScheduleInfo("Розклад занять на 1 семестр 2022/23 н.р.", DateTime.Now.AddDays(-30)),
            //new ScheduleInfo("Розклад МК1 2022/23 н.р.", DateTime.Now)
        };

        public Task Create(Schedule schedule)
        {
            return Task.CompletedTask;
        }

        public Task Delete(string name)
        {
            return Task.CompletedTask;
        }

        public Task<ScheduleInfo?> Get(string name)
        {
            return Task.FromResult(schedules.FirstOrDefault(s => s.Name == name));
        }

        public Task<IEnumerable<ScheduleInfo>> GetAvailableSchedules()
        {
            return Task.FromResult<IEnumerable<ScheduleInfo>>(schedules);
        }
    }
}
