using HabitTracker.WebUI.Controllers;
using HabitTracker.WebUI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HabitTracker.WebUI.Pages
{
    public class DeleteHabitLogModel : PageModel
    {
        private readonly IHabitLogController _habitLogController;

        public DeleteHabitLogModel(IHabitLogController habitLogController)
        {
            _habitLogController = habitLogController;
        }

        [BindProperty]
        public HabitLogDto? HabitLog { get; set; }

        public IActionResult OnGet(Guid habitLogId)
        {
            HabitLog = _habitLogController.GetHabitLog(habitLogId);
            if (HabitLog == null)
            {
                return NotFound();
            }
            else
            {
                return Page();
            }
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // TODO: What is the best practice here?
            if (HabitLog == null)
            {
                return BadRequest(ModelState);
            }

            var result = _habitLogController.DeleteHabitLog(HabitLog.Id);
            if (result)
            {
                return RedirectToPage("./ViewHabitLogs", new { habitId = HabitLog.HabitId });
            }
            else
            {
                // TODO: What is the best practice here?
                return BadRequest();
            }
        }
    }
}
