using Microsoft.Extensions.DependencyInjection;
using System;

namespace Mobile
{
    public static class Startup
    {
        public static IServiceProvider ServiceProvider { get; private set; }

        public static IServiceProvider Init(Action<IServiceCollection> addPlatformSpecificServices)
        {
            var serviceProvider = new ServiceCollection()
                .ConfigureServices(addPlatformSpecificServices)
                .BuildServiceProvider();

            ServiceProvider = serviceProvider;

            return serviceProvider;
        }
    }
}