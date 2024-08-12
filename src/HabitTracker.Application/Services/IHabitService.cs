using HabitTracker.Domain.Entities;

namespace HabitTracker.Application.Services;

public interface IHabitService
{
    int AddHabit(Habit habit);
    Habit? GetHabit(Guid id);
    List<Habit> GetHabits();
    int UpdateHabit(Habit habit);
}
