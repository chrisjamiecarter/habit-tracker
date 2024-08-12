using HabitTracker.WebUI.Controllers;
using HabitTracker.WebUI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HabitTracker.WebUI.Pages;

public class UpdateHabitLogModel : PageModel
{
    private readonly IHabitLogController _habitLogController;

    public UpdateHabitLogModel(IHabitLogController habitLogController)
    {
        _habitLogController = habitLogController;
    }

    [BindProperty]
    public HabitLogDto? HabitLog { get; set; }

    public IActionResult OnGet(Guid id)
    {
        HabitLog = _habitLogController.GetHabitLog(id);
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

        var request = new UpdateHabitLogRequest
        {
            Id = HabitLog.Id,
            Date = HabitLog.Date,
            Quantity = HabitLog.Quantity,
        };

        var result = _habitLogController.UpdateHabitLog(request);
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
