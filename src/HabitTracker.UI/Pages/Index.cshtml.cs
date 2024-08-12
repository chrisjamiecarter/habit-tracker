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

    public IReadOnlyList<HabitDto> Habits { get; set; } = [];

    public void OnGet()
    {
        Habits = GetHabits();
        //ViewData["Total"] = Habits.Sum(x => x.Quantity);
        ViewData["HabitsCount"] = Habits.Count;
    }

    private IReadOnlyList<HabitDto> GetHabits()
    {
        return _habitController.GetHabits();
    }
}
