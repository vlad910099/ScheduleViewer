using System;
using System.Collections.Generic;
using System.Text;
using Domain.Repositoryes;
using Domain.Interfaces;
using UDUNT_TimeTable.Services;
using Microsoft.Extensions.DependencyInjection;
using UDUNT_TimeTable.Persistence.InMemory;

namespace UDUNT_TimeTable
{
public static class DependencyInjectionContainer
{
    public static IServiceCollection ConfigureServices(this IServiceCollection services)
    {
        services.AddScoped<ITeacherRepository, InMemoryTeacherRepository>();
        services.AddScoped<IGroupRepository, InMemoryGroupRepository>();
        services.AddScoped<IClassRepository, InMemoryClassRepository>();
        services.AddScoped<IScheduleRepository, InMemoryScheduleRepository>();

        services.AddScoped<IScheduleProvider, InMemoryScheduleProvider>();

        services.AddScoped<ScheduleService>();

        return services;
    }
}
}
