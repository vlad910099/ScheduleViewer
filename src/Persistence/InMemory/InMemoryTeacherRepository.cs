using Domain;
using Domain.Interfaces;
using Domain.Models;
using Domain.Repositoryes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



namespace Persistence.InMemory
{
    public class InMemoryTeacherRepository : ITeacherRepository
    {
        private readonly IClassRepository classRepository;

        public InMemoryTeacherRepository(IClassRepository classRepository)
        {
            this.classRepository = classRepository;
        }

        public async Task<IEnumerable<Teacher>> Get(string scheduleName)
        {
            var searchCriteria = new SearchCriteria(scheduleName, null, null);
            var classes = await classRepository.Get(searchCriteria);

            return classes.Where(c => c.Teacher.Name != "-").Select(c => c.Teacher).Distinct().ToList();
            //Where(c => c.Teacher != null)
        }

        public async Task<IEnumerable<Teacher>> Get(string scheduleName, string name)
        {
            var teachers = await Get(scheduleName);
            return teachers.Where(t => t.Name.Contains(name)).ToList();
        }
    }
}