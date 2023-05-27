using Domain.Models;
using Domain.PersistenceInterfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Persistence.InMemory
{
    public class InMemoryTeacherRepository : ITeacherRepository
    {
        private readonly IScheduleRepository scheduleRepository;

        public InMemoryTeacherRepository(IScheduleRepository scheduleRepository)
        {
            this.scheduleRepository = scheduleRepository;
        }

        public async Task<IEnumerable<Teacher>> Get(string scheduleName)
        {
            var classes = await scheduleRepository.GetClasses(scheduleName);
            return classes.Where(c => c.Teacher != null && c.Teacher.Name != "-").Select(c => c.Teacher).Distinct().ToList();
        }
    }
}