namespace HabitTracker.Infrastructure.Contexts;

/// <summary>
/// Contract for the database context.
/// </summary>
public interface IDbContext
{
    string ConnectionString { get; }
    void EnsureCreated();
}