using Domain;
using Domain.Interfaces;
using Domain.Models;
using Domain.Repositoryes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UDUNT_TimeTable.Persistence.InMemory
{
    public class InMemoryGroupRepository : IGroupRepository
    {
        private readonly IClassRepository classRepository;

        public InMemoryGroupRepository(IClassRepository classRepository)
        {
            this.classRepository = classRepository;
        }

        public async Task<IEnumerable<Group>> Get(string scheduleName)
        {
            var searchCriteria = new SearchCriteria(scheduleName, null, null);
            var classes = await classRepository.Get(searchCriteria);

            return classes.Select(c => c.Group).Distinct().ToList();
        }

        public async Task<IEnumerable<Group>> Get(string scheduleName, string name)
        {
            var groups = await Get(scheduleName);
            return groups.Where(t => t.Name.Contains(name)).ToList();
        }
    }
}