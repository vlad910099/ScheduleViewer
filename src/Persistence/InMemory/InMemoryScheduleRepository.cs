using Domain.Interfaces;
using Domain.Models;
using Domain.Repositoryes;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Persistence.InMemory
{
    public class InMemoryScheduleRepository : IScheduleRepository
    {
        private readonly IClassRepository classRepository;

        public InMemoryScheduleRepository(IClassRepository classRepository)
        {
            this.classRepository = classRepository;
        }

        private static readonly List<ScheduleInfo> schedules = new List<ScheduleInfo>();

        public async Task Create(Schedules schedule)
        {
            var scheduleInfo = new ScheduleInfo(schedule.Name, schedule.Year, schedule.Url, schedule.Checksum);
            schedules.Add(scheduleInfo);

            foreach (var item in schedule.Classes)
            {
                await classRepository.Create(item);
            }
        }

        public async Task Delete(string name)
        {
            var scheduleInfo = schedules.FirstOrDefault(s => s.Name == name);

            if (scheduleInfo != null)
            {
                schedules.Remove(scheduleInfo);
                await classRepository.Delete(name);
            }
        }

        public Task<ScheduleInfo?> Get(string name)
        {
            return Task.FromResult(schedules.FirstOrDefault(s => s.Name == name));
        }

        public Task<ScheduleInfo[]> GetSchedules()
        {
            
            return Task.FromResult(schedules.ToArray());
        }
    }
}