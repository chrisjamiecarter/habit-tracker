using HabitTracker.WebUI.Models;

namespace HabitTracker.WebUI.Controllers;
public interface IHabitController
{
    bool AddHabit(CreateHabitRequest request);
    HabitDto? GetHabit(Guid id);
    IReadOnlyList<HabitDto> GetHabits();
    bool IsUniqueHabitName(string name);
    bool UpdateHabit(UpdateHabitRequest request);
}