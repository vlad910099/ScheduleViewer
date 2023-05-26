using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositoryes
{
    public interface IClassRepository
    {
        Task Create(Class @class);
        Task<IEnumerable<Class>> Get(SearchCriteria searchCriteria);
        Task Delete(string scheduleName);
    }
}
