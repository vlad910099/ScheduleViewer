using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Interfaces;
using Domain.Models;

namespace UDUNT_TimeTable.Persistence.InMemory
{
    public class InMemoryGroupRepository : IGroupRepository
    {
        private static List<Group> groups = new List<Group>()
        {
            new Group("ПЗ22130", "920П"),
            new Group("ПЗ2112", "922"),
            new Group("ПЗ2111", "921")
        };

        public Task Create(Group group)
        {
            groups.Add(group);
            return Task.CompletedTask;
        }

        public Task<IEnumerable<Group>> Get()
        {
            return Task.FromResult<IEnumerable<Group>>(groups);
        }

        public Task<Group?> Get(string name)
        {
            return Task.FromResult(groups.FirstOrDefault(t => t.Name == name));
        }
    }
}
