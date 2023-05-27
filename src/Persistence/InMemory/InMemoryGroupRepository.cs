using Domain.Models;
using Domain.PersistenceInterfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Persistence.InMemory
{
    public class InMemoryGroupRepository : IGroupRepository
    {
        private readonly IScheduleRepository scheduleRepository;

        public InMemoryGroupRepository(IScheduleRepository scheduleRepository)
        {
            this.scheduleRepository = scheduleRepository;
        }

        public async Task<IEnumerable<Group>> Get(string scheduleName)
        {
            var classes = await scheduleRepository.GetClasses(scheduleName);
            return classes.Select(c => c.Group).Distinct().ToList();
        }
    }
}