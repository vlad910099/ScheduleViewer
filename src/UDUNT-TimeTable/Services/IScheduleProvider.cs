using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace UDUNT_TimeTable.Services
{
    public interface IScheduleProvider
    {
        Task<string[]> GetAvailableScheduleNames();
        Task<ScheduleInfo> GetInfo(string name);
        Task<Schedule> Get(string name);
    }
}
