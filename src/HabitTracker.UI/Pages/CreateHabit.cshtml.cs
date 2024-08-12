using HabitTracker.WebUI.Controllers;
using HabitTracker.WebUI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HabitTracker.WebUI.Pages
{
    public class CreateHabitModel : PageModel
    {
        private readonly IHabitController _habitController;

        public CreateHabitModel(IHabitController habitController)
        {
            _habitController = habitController;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public HabitDto Habit { get; set; }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (Habit == null)
            {
                return BadRequest(ModelState);
            }

            var request = new CreateHabitRequest
            {
                Name = Habit.Name,
                Measure = Habit.Measure,
            };

            var result = _habitController.AddHabit(request);
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
