using Domain;
using Domain.Models;
using Domain.Repositoryes;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Persistence.InMemory
{
    public class InMemoryClassRepository : IClassRepository
    {
        private static List<Class> classes = new List<Class>();

        public Task Create(Class @class)
        {
            classes.Add(@class);
            return Task.CompletedTask;
        }

        public Task Delete(string scheduleName)
        {
            var toDelete = classes.Where(c => c.ScheduleName == scheduleName).ToList();

            foreach (var toDeleteItem in toDelete)
            {
                classes.Remove(toDeleteItem);
            }

            return Task.CompletedTask;
        }

        public Task<IEnumerable<Class>> Get(SearchCriteria searchCriteria)
        {
            var result = classes.Where(c => c.ScheduleName == searchCriteria.ScheduleName);

            if (!string.IsNullOrEmpty(searchCriteria.TeacherName))
            {
                result = result.Where(c => c.Teacher.Name.Equals(searchCriteria.TeacherName));
            }

            if (!string.IsNullOrEmpty(searchCriteria.GroupName))
            {
                result = result.Where(c => c.Group.Name.Equals(searchCriteria.GroupName));
            }

            return Task.FromResult<IEnumerable<Class>>(result.ToList());
        }
    }
}