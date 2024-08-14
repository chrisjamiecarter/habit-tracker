using HabitTracker.WebUI.Controllers;
using HabitTracker.WebUI.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HabitTracker.WebUI.Pages;
public class IndexModel : PageModel
{
    private readonly IHabitController _habitController;

    public IndexModel(IHabitController habitController)
    {
        _habitController = habitController;
    }

    public string SelectedFilter { get; set; }

    public IReadOnlyList<HabitDto> Habits { get; set; } = [];

    public IReadOnlyList<HabitDto> FilteredHabits { get; set; } = [];

    public void OnGet(string isActiveFilter)
    {
        Habits = GetHabits();

        // Default to Active.
        if (isActiveFilter is null)
        {
            isActiveFilter = "true";
        }

        SelectedFilter = isActiveFilter;

        if (isActiveFilter.Equals("all"))
        {
            FilteredHabits = Habits;
        }
        else
        {
            var isActive = bool.Parse(isActiveFilter);
            FilteredHabits = Habits.Where(h => h.IsActive == isActive).ToList();
        }

        //ViewData["Total"] = Habits.Sum(x => x.Quantity);
        ViewData["HabitsCount"] = Habits.Count;
    }

    private IReadOnlyList<HabitDto> GetHabits()
    {
        return _habitController.GetHabits();
    }
}
