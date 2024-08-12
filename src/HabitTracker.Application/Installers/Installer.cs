using HabitTracker.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace HabitTracker.Application.Installers;

public static class Installer
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IHabitService, HabitService>();
        services.AddScoped<IHabitLogService, HabitLogService>();

        return services;
    }
}
