using HabitTracker.Application.Repositories;
using HabitTracker.Domain.Entities;
using HabitTracker.Domain.Helpers;

namespace HabitTracker.Application.Services;

/// <summary>
/// Implementation of the Habit service. Interacts with the Habit repository.
/// </summary>
public class HabitService : IHabitService
{
    #region Fields
    
    private readonly IHabitRepository _repository;

    #endregion
    #region Constructors
    
    public HabitService(IHabitRepository repository)
    {
        _repository = repository;
    }

    #endregion
    #region Methods
    
    public ResponsePackage AddHabit(Habit habit)
    {
        var habitFromDb = _repository.GetHabit(habit.Name);

        if(habitFromDb != null)
        {
            return new ResponsePackage { IsSuccess = false, Message = $"Habit with name: {habit.Name} already exist in database " };
        }

        try
        {
            _repository.AddHabit(habit);
            return new ResponsePackage { IsSuccess = true, Message = $"Habit with name: {habit.Name} successfully added" };
        }
        catch(Exception ex)
        {
            return new ResponsePackage { IsSuccess = false, Message = ex.Message };
        }
    }

    public Habit? GetHabit(Guid id)
    {
        return _repository.GetHabit(id);
    }

    public List<Habit> GetHabits()
    {
        return _repository.GetHabits();
    }

    public bool IsUniqueHabitName(string name)
    {
        return _repository.GetHabit(name) is null;
    }

    public int UpdateHabit(Habit habit)
    {
        return _repository.UpdateHabit(habit);
    }

    #endregion
}
