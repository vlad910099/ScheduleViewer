using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface ITeacherRepository
    {
        Task<IEnumerable<Teacher>> Get(string scheduleName);
        Task<IEnumerable<Teacher>> Get(string scheduleName, string name);
    }
}
