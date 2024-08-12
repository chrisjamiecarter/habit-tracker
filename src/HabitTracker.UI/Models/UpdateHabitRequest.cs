namespace HabitTracker.WebUI.Models;

public class UpdateHabitRequest
{
    #region Properties

    public Guid Id { get; set; }

    public string Name { get; set; }

    public string Measure { get; set; }

    public bool IsActive { get; set; }

    #endregion
}
