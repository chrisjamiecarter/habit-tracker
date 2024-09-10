using HabitTracker.Domain.Helpers;
using HabitTracker.WebUI.Models;

namespace HabitTracker.WebUI.Controllers;

/// <summary>
/// Contract for the HabitController.
/// </summary>
public interface IHabitController
{
    ResponsePackage AddHabit(CreateHabitRequest request);
    HabitDto? GetHabit(Guid id);
    IReadOnlyList<HabitDto> GetHabits();
    bool IsUniqueHabitName(string name);
    ResponsePackage UpdateHabit(UpdateHabitRequest request);
}