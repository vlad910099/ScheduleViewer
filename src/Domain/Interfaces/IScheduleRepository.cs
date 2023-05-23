﻿using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IScheduleRepository
    {
        Task<IEnumerable<ScheduleInfo>> GetAvailableSchedules();
        Task<ScheduleInfo?> Get(string name);
        Task Delete(string name);
        Task Create(Schedules schedule);
    }
}
