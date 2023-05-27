using Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.PersistenceInterfaces
{
    public interface IScheduleRepository
    {
        Task<ScheduleInfo[]> Get();

        Task<ScheduleInfo> GetInfo(string name);

        Task<IEnumerable<Class>> GetClasses(string name);

        Task<IEnumerable<Class>> GetClasses(SearchCriteria searchCriteria);

        Task Delete(string name);

        Task Create(Schedule schedule);
    }
}