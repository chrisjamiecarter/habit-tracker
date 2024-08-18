using HabitTracker.Domain.Entities;
using HabitTracker.WebUI.Controllers;
using HabitTracker.WebUI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HabitTracker.WebUI.Pages
{
    public class DeleteHabitLogModel : PageModel
    {
        private readonly IHabitController _habitController;
        private readonly IHabitLogController _habitLogController;

        public DeleteHabitLogModel(IHabitController habitController, IHabitLogController habitLogController)
        {
            _habitController = habitController;
            _habitLogController = habitLogController;
        }

        public HabitDto? Habit { get; set; }

        [BindProperty]
        public HabitLogDto? HabitLog { get; set; }

        public IActionResult OnGet(Guid habitLogId)
        {
            HabitLog = _habitLogController.GetHabitLog(habitLogId);
            if (HabitLog == null)
            {
                return RedirectToPage("./Error", new { errorMessage = $"No habit log found with Id: {habitLogId}" });
            }

            Habit = _habitController.GetHabit(HabitLog.HabitId);
            if (Habit is null)
            {
                return RedirectToPage("./Error", new { errorMessage = $"No habit found with Id: {HabitLog.HabitId}" });
            }

            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var result = _habitLogController.DeleteHabitLog(HabitLog!.Id);
            if (result)
            {
                return RedirectToPage("./ViewHabitLogs", new { habitId = HabitLog.HabitId });
            }
            else
            {
                return RedirectToPage("./Error", new { errorMessage = "There was an error deleting the habit log from the database." });
            }
        }
    }
}
