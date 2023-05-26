using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IGroupRepository
    {
        Task<IEnumerable<Group>> Get(string scheduleName);
        Task<IEnumerable<Group>> Get(string scheduleName, string name);
    }
}
