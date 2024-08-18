using HabitTracker.Domain.Entities;
using HabitTracker.WebUI.Controllers;
using HabitTracker.WebUI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HabitTracker.WebUI.Pages
{
    public class CreateHabitLogModel : PageModel
    {
        private readonly IHabitController _habitController;
        private readonly IHabitLogController _habitLogController;

        public CreateHabitLogModel(IHabitController habitController, IHabitLogController habitLogController)
        {
            _habitController = habitController;
            _habitLogController = habitLogController;
        }

        public HabitDto? Habit { get; set; }

        [BindProperty]
        public HabitLogDto HabitLog { get; set; }

        public IActionResult OnGet(Guid habitId)
        {
            Habit = _habitController.GetHabit(habitId);
            if (Habit is null)
            {
                return RedirectToPage("./Error", new { errorMessage = $"No habit found with Id: {habitId}" });
            }

            HabitLog = new HabitLogDto
            {
                HabitId = habitId,
                Date = DateTime.Today,
                Quantity = 0,
            };

            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var request = new CreateHabitLogRequest
            {
                HabitId = HabitLog.HabitId,
                Date = HabitLog.Date,
                Quantity = HabitLog.Quantity,
            };

            var result = _habitLogController.AddHabitLog(request);
            if (result)
            {
                return RedirectToPage("./ViewHabitLogs", new { habitId = HabitLog.HabitId });
            }
            else
            {
                return RedirectToPage("./Error", new { errorMessage = "There was an error adding the habit log to the database." });
            }
        }
    }
}
