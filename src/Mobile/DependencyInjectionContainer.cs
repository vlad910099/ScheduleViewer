using Core.Parsers;
using Core.Services;
using Domain.PersistenceInterfaces;
using Microsoft.Extensions.DependencyInjection;
using Persistence.InMemory;
using Persistence.SQLiteDb;
using System;

namespace Mobile
{
    public static class DependencyInjectionContainer
    {
        public static IServiceCollection ConfigureServices(this IServiceCollection services, Action<IServiceCollection> addPlatformSpecificServices)
        {
            addPlatformSpecificServices.Invoke(services);

            //services = services.AddInMemoryRepositories();
            services = services.AddDbRepositories();

            services.AddScoped<IScheduleProvider, SiteScheduleProvider>();

            services.AddScoped<IFileScheduleParser, ClassFileParser>();
            services.AddScoped<IFileScheduleParser, ModuleFileParser>();

            services.AddScoped<ScheduleService>();

            return services;
        }

        private static IServiceCollection AddInMemoryRepositories(this IServiceCollection services)
        {
            services.AddScoped<ITeacherRepository, InMemoryTeacherRepository>();
            services.AddScoped<IGroupRepository, InMemoryGroupRepository>();
            services.AddScoped<IScheduleRepository, InMemoryScheduleRepository>();

            return services;
        }

        private static IServiceCollection AddDbRepositories(this IServiceCollection services)
        {
            services.AddSingleton<SQLiteDatabase>();

            services.AddScoped<ITeacherRepository, SQLiteTeacherRepository>();
            services.AddScoped<IGroupRepository, SQLiteGroupRepository>();
            services.AddScoped<IScheduleRepository, SQLiteScheduleRepository>();

            return services;
        }
    }
}