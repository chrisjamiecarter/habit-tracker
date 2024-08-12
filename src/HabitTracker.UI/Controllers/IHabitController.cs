using HabitTracker.WebUI.Models;

namespace HabitTracker.WebUI.Controllers;
public interface IHabitController
{
    bool AddHabit(CreateHabitRequest request);
    HabitDto? GetHabit(Guid id);
    IReadOnlyList<HabitDto> GetHabits();
    bool UpdateHabit(UpdateHabitRequest request);
}