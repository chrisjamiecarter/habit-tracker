using HabitTracker.Infrastructure.Queries;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Configuration;

namespace HabitTracker.Infrastructure.Contexts;

internal class DbContext : IDbContext
{
    public DbContext(IConfiguration configuration)
    {
        string? connectionString = configuration.GetConnectionString("Default");

        ArgumentException.ThrowIfNullOrWhiteSpace(connectionString, nameof(connectionString));

        ConnectionString = connectionString;

        EnsureCreated();
    }

    public string ConnectionString { get; }

    public void EnsureCreated()
    {
        CreateHabitTable();
        CreateHabitLogTable();
    }

    private void CreateHabitTable()
    {
        using var connection = new SqliteConnection(ConnectionString);
        connection.Open();

        using var command = connection.CreateCommand();
        command.CommandText = TableQueries.CreateHabitTable;
        command.ExecuteNonQuery();
    }

    private void CreateHabitLogTable()
    {
        using var connection = new SqliteConnection(ConnectionString);
        connection.Open();

        using var command = connection.CreateCommand();
        command.CommandText = TableQueries.CreateHabitLogTable;
        command.ExecuteNonQuery();
    }
}
