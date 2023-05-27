using Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.PersistenceInterfaces
{
    public interface ITeacherRepository
    {
        Task<IEnumerable<Teacher>> Get(string scheduleName);
    }
}