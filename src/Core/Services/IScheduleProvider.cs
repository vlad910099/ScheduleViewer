using Domain.Models;
using System.Threading.Tasks;

namespace Core.Services
{
    public interface IScheduleProvider
    {
        Task<ScheduleInfo[]> GetScheduleInfos();

        Task<ScheduleInfo> ExtendScheduleInfo(ScheduleInfo initialScheduleInfo);

        Task<Schedule> Get(ScheduleInfo scheduleInfo);
    }
}