using System;
using AppStore.DL.Interfaces;
using AppStore.DL.Repositories;
using Microsoft.Extensions.DependencyInjection;
namespace AppStore.DL;

public static class DependancyInjection
{

    public static void RegisterRepositories(this IServiceCollection services)
    {
        services
            .AddSingleton<IAppRepository, AppRepository>()
            .AddSingleton<IOperatingSystemRepository, OperatingSystemRepository>();
    }

}
