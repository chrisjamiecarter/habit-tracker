using HabitTracker.WebUI.Controllers;
using Microsoft.Extensions.DependencyInjection;

namespace HabitTracker.WebUI.Installers;

public static class Installer
{
    public static IServiceCollection AddWebUI(this IServiceCollection services)
    {
        services.AddScoped<IHabitController, HabitController>();
        services.AddScoped<IHabitLogController, HabitLogController>();

        return services;
    }
}
