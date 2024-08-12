using HabitTracker.Application.Repositories;
using HabitTracker.Domain.Entities;

namespace HabitTracker.Application.Services;

public class HabitService : IHabitService
{
    private readonly IHabitRepository _repository;

    public HabitService(IHabitRepository repository)
    {
        _repository = repository;
    }

    public int AddHabit(Habit habit)
    {
        return _repository.AddHabit(habit);
    }

    public Habit? GetHabit(Guid id)
    {
        return _repository.GetHabit(id);
    }

    public List<Habit> GetHabits()
    {
        return _repository.GetHabits();
    }

    public int UpdateHabit(Habit habit)
    {
        return _repository.UpdateHabit(habit);
    }
}
