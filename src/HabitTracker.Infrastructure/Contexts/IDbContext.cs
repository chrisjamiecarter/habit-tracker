namespace HabitTracker.Infrastructure.Contexts;

internal interface IDbContext
{
    string ConnectionString { get; }

    void EnsureCreated();
}