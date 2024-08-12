using HabitTracker.WebUI.Controllers;
using HabitTracker.WebUI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HabitTracker.WebUI.Pages
{
    public class UpdateHabitModel : PageModel
    {
        private readonly IHabitController _habitController;

        public UpdateHabitModel(IHabitController habitController)
        {
            _habitController = habitController;
        }

        [BindProperty]
        public HabitDto? Habit { get; set; }

        public IActionResult OnGet(Guid id)
        {
            Habit = _habitController.GetHabit(id);

            if (Habit == null)
            {
                BadRequest($"No Habit found with Id {id}");
            }

            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            if (Habit is null)
            {
                return BadRequest(ModelState);
            }

            var request = new UpdateHabitRequest
            {
                Id = Habit.Id,
                Name = Habit.Name,
                Measure = Habit.Measure,
                IsActive = Habit.IsActive,
            };

            var result = _habitController.UpdateHabit(request);
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
