using HabitTracker.Domain.Entities;
using HabitTracker.WebUI.Controllers;
using HabitTracker.WebUI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HabitTracker.WebUI.Pages
{
    public class CreateHabitLogModel : PageModel
    {
        private readonly IHabitLogController _habitLogController;

        public CreateHabitLogModel(IHabitLogController habitLogController)
        {
            _habitLogController = habitLogController;
        }

        [BindProperty]
        public Guid HabitId { get; set; }

        [BindProperty]
        public HabitLogDto HabitLog { get; set; }

        public IActionResult OnGet(Guid habitId)
        {
            HabitId = habitId;
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (HabitLog == null)
            {
                return BadRequest(ModelState);
            }

            var request = new CreateHabitLogRequest
            {
                HabitId = HabitId,
                Date = HabitLog.Date,
                Quantity = HabitLog.Quantity,
            };

            var result = _habitLogController.AddHabitLog(request);
            if (result)
            {
                return RedirectToPage("./Index");
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
