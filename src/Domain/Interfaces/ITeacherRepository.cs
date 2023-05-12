using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface ITeacherRepository
    {
        Task<IEnumerable<Teacher>> Get();
        Task<Teacher?> Get(string name);
        Task Create(Teacher teacher);
    }
}
