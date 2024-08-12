namespace HabitTracker.Domain.Entities;

public class HabitLog
{
    #region Properties

    public Guid Id { get; set; }

    public Guid HabitId { get; set; }

    public DateTime Date { get; set; }

    public int Quantity { get; set; }

    #endregion
}
