using Domain;
using Domain.Models;
using Domain.PersistenceInterfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Persistence.InMemory
{
    public class InMemoryScheduleRepository : IScheduleRepository
    {
        private static readonly List<Schedule> schedules = new List<Schedule>();

        public Task Create(Schedule schedule)
        {
            schedules.Add(schedule);
            return Task.CompletedTask;
        }

        public Task Delete(string name)
        {
            var schedule = schedules.Find(s => s.Info.Name == name);

            if (schedule != null)
            {
                schedules.Remove(schedule);
            }

            return Task.CompletedTask;
        }

        public Task<ScheduleInfo[]> Get()
        {
            return Task.FromResult(schedules.Select(s => s.Info).ToArray());
        }

        public Task<IEnumerable<Class>> GetClasses(string name)
        {
            return Task.FromResult(schedules.Find(s => s.Info.Name == name)?.Classes);
        }

        public Task<IEnumerable<Class>> GetClasses(SearchCriteria searchCriteria)
        {
            var classes = schedules.Find(s => s.Info.Name == searchCriteria.ScheduleName)?.Classes;

            if (!string.IsNullOrEmpty(searchCriteria.TeacherName))
            {
                classes = classes.Where(c => c.Teacher?.Name == searchCriteria.TeacherName);
            }

            if (!string.IsNullOrEmpty(searchCriteria.GroupName))
            {
                classes = classes.Where(c => c.Group.Name == searchCriteria.GroupName);
            }

            return Task.FromResult<IEnumerable<Class>>(classes.ToList());
        }

        public Task<ScheduleInfo> GetInfo(string name)
        {
            return Task.FromResult(schedules.Find(s => s.Info.Name == name)?.Info);
        }
    }
}