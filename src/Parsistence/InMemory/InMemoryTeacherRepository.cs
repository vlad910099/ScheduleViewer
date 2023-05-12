using Domain.Interfaces;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UDUNT_TimeTable.Persistence.InMemory
{
    public class InMemoryTeacherRepository : ITeacherRepository
    {
        private static List<Teacher> teachers = new List<Teacher>
        {
            new Teacher("ст.в.Самойлов С.П."),
            new Teacher("доц.Нечай І.В."),
            new Teacher("ст.в.Шаповал І.В."),
            new Teacher("доц.Горбова О.В."),
            new Teacher("доц.Куроп'ятник О.С.")
        };

        public Task Create(Teacher teacher)
        {
            teachers.Add(teacher);
            return Task.CompletedTask;
        }

        public Task<IEnumerable<Teacher>> Get()
        {
            return Task.FromResult<IEnumerable<Teacher>>(teachers);
        }

        public Task<Teacher?> Get(string name)
        {
            return Task.FromResult(teachers.FirstOrDefault(t => t.Name == name));
        }
    }
}
