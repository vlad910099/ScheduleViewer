using Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.PersistenceInterfaces
{
    public interface IGroupRepository
    {
        Task<IEnumerable<Group>> Get(string scheduleName);
    }
}