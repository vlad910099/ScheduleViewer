using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace UDUNT_TimeTable.Services
{
    public interface IScheduleProvider
    {
        Task<ScheduleInfo[]> GetSchedules();
        Task<ScheduleInfo> GetScheduleInfo(ScheduleInfo initialScheduleInfo);
        Task<Schedules> Get(ScheduleInfo scheduleInfo);


    }
}
