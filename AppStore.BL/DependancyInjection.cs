using System;
using AppStore.BL.Interfaces;
using AppStore.BL.Services;
using AppStore.DL;
using Microsoft.Extensions.DependencyInjection;

namespace AppStore.BL;

public static class DependancyInjection
{

    public static IServiceCollection RegisterBusinessLayer(this IServiceCollection services)
    {
        services.AddSingleton<IAppService, AppService>();
        services.AddSingleton<IOperatingSystemService, OperatingSystemService>();
        services.AddSingleton<IAppBlService, AppBlService>();
        return services;

    }

    public static IServiceCollection RegisterDataLayer(this IServiceCollection services)
    {
        services.RegisterRepositories();

        return services;
    }

}
