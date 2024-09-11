using System.ComponentModel.DataAnnotations;
using HabitTracker.Application.Repositories;
using HabitTracker.Infrastructure.Contexts;

namespace HabitTracker.WebUI.Validators;

public class UniqueNameAttribute : ValidationAttribute
{

    protected override ValidationResult IsValid(object value,
    ValidationContext validationContext)
    {
        var existingId = validationContext.ObjectType.GetProperty("Id")?.GetValue(validationContext.ObjectInstance) as Guid?;
        var serviceProvider = validationContext.GetService<IServiceProvider>();
        var repository = serviceProvider.GetRequiredService<IHabitRepository>();
        var habitName = value?.ToString();

        if (string.IsNullOrWhiteSpace(habitName))
        {
            return new ValidationResult("Habit name is required.");
        }

        //update - check only if change name
        if (existingId.HasValue && existingId.Value != Guid.Empty)
        {
            var data = repository.GetHabit(existingId.Value);
            if(data != null && data.Name == habitName)
                return ValidationResult.Success;
        }

        var habitFromDb = repository.GetHabit(habitName);
        if (habitFromDb == null)
        {
            return ValidationResult.Success;
        }

        return new ValidationResult($"Habit with name: '{habitName}' already exists.");
    }
}
