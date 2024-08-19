using HabitTracker.Application.Services;
using HabitTracker.Domain.Entities;
using HabitTracker.WebUI.Models;

namespace HabitTracker.WebUI.Controllers;

public class HabitController : IHabitController
{
    private readonly IHabitService _service;

    public HabitController(IHabitService service)
    {
        _service = service;
    }

    public bool AddHabit(CreateHabitRequest request)
    {
        var habit = new Habit
        {
            Id = request.Id,
            Name = request.Name,
            Measure = request.Measure,
            IsActive = true,
        };

        var result = _service.AddHabit(habit);
        return result > 0;        
    }

    public HabitDto? GetHabit(Guid id)
    {
        var habit = _service.GetHabit(id);
        return habit is null ? null : new HabitDto(habit);
    }

    public IReadOnlyList<HabitDto> GetHabits()
    {
        return _service.GetHabits()
            .Select(x => new HabitDto(x))
            .ToList();
    }

    public bool UpdateHabit(UpdateHabitRequest request)
    {
        var habit = _service.GetHabit(request.Id);     
        if (habit is null)
        {
            return false;
        }

        habit.Name = request.Name;
        habit.Measure = request.Measure;
        habit.IsActive = request.IsActive;

        var result = _service.UpdateHabit(habit);
        return result > 0;
    }

}
