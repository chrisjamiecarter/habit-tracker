namespace HabitTracker.WebUI.Models;

public class UpdateHabitLogRequest
{
    #region Properties

    public Guid Id { get; set; }

    public DateTime Date { get; set; }

    public int Quantity { get; set; }

    #endregion
}
