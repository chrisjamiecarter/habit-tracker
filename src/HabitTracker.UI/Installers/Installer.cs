using HabitTracker.Application.Repositories;
using HabitTracker.Infrastructure.Contexts;
using HabitTracker.Infrastructure.Repositories;
using HabitTracker.WebUI.Controllers;

namespace HabitTracker.WebUI.Installers;

/// <summary>
/// Installs all dependancies for the web application project.
/// </summary>
public static class Installer
{
    public static IServiceCollection AddWebUI(this IServiceCollection services)
    {
        services.AddScoped<IHabitController, HabitController>();
        services.AddScoped<IHabitRepository, HabitRepository>();
        services.AddScoped<IHabitLogController, HabitLogController>();

        return services;
    }
}
