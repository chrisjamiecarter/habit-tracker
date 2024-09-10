using HabitTracker.Application.Services;
using HabitTracker.Domain.Entities;
using HabitTracker.Domain.Helpers;
using HabitTracker.WebUI.Models;

namespace HabitTracker.WebUI.Controllers;

/// <summary>
/// Controls all Habit specific interactions from the WebUI to the other layers.
/// </summary>
public class HabitController : IHabitController
{
    #region Fields

    private readonly IHabitService _service;

    #endregion
    #region Constructors

    public HabitController(IHabitService service)
    {
        _service = service;
    }

    #endregion
    #region Methods

    public ResponsePackage AddHabit(CreateHabitRequest request)
    {
        var habit = new Habit
        {
            Id = request.Id,
            Name = request.Name,
            Measure = request.Measure,
            IsActive = true,
        };

        var result = _service.AddHabit(habit);
        return result;
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

    public bool IsUniqueHabitName(string name)
    {
        return _service.IsUniqueHabitName(name);
    }

    public ResponsePackage UpdateHabit(UpdateHabitRequest request)
    {
        var habit = _service.GetHabit(request.Id);
        if (habit is null)
        {
            return new ResponsePackage() { IsSuccess = false, Message= "Habit don't exist with this id in database" };
        }

        if (habit.Name != request.Name)
        {
            var habitFromDb = _service.GetHabitByName(request.Name);
            if (habitFromDb != null)
            {
                return new ResponsePackage { IsSuccess = false, Message = $"Habit with name: {habit.Name} already exist in database " };
            }
        }

        habit.Name = request.Name;
        habit.Measure = request.Measure;
        habit.IsActive = request.IsActive;

        var result = _service.UpdateHabit(habit);
        return result > 0
            ? new ResponsePackage { IsSuccess = true, Message = $"Habit with name: {habit.Name} successfully updated" }
            : new ResponsePackage() { IsSuccess = false, Message = $"There was an error updating the habit with name: {habit.Name} in the database." };
    }

    #endregion
}
