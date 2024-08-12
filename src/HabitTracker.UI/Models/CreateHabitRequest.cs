namespace HabitTracker.WebUI.Models;

public class CreateHabitRequest
{
    #region Properties

    public Guid Id { get; private set; } = Guid.NewGuid();

    public string Name { get; set; }

    public string Measure { get; set; }

    #endregion
}
