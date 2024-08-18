using HabitTracker.WebUI.Controllers;
using HabitTracker.WebUI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HabitTracker.WebUI.Pages;

public class ViewHabitLogsModel : PageModel
{
    private readonly IHabitController _habitController;
    private readonly IHabitLogController _habitLogController;

    public ViewHabitLogsModel(IHabitController habitController, IHabitLogController habitLogController)
    {
        _habitController = habitController;
        _habitLogController = habitLogController;
    }

    public HabitDto? Habit { get; set; }

    public IReadOnlyList<HabitLogDto> HabitLogs { get; set; } = [];

    public IActionResult OnGet(Guid habitId)
    {
        Habit = _habitController.GetHabit(habitId);
        if (Habit is null)
        {
            return RedirectToPage("./Error", new { errorMessage = $"No habit found with Id: {habitId}" });
        }

        HabitLogs = _habitLogController.GetHabitLogs(habitId);
        ViewData["HabitLogsCount"] = HabitLogs.Count;

        return Page();
    }
}
