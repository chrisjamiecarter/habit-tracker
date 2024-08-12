using HabitTracker.Domain.Entities;

namespace HabitTracker.Application.Repositories;

public interface IHabitRepository
{
    int AddHabit(Habit habit);
    Habit? GetHabit(Guid id);
    List<Habit> GetHabits();
    List<Habit> GetHabitsByIsActive(bool isActive);
    int UpdateHabit(Habit habit);
}
