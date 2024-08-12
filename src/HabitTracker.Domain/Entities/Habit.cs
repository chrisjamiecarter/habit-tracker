namespace HabitTracker.Domain.Entities;

public class Habit
{
    #region Properties

    public Guid Id { get; set; }

    public string Name { get; set; }

    public string Measure { get; set; }

    public bool IsActive { get; set; }

    #endregion
}
