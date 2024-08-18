using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HabitTracker.WebUI.Pages;

public class ErrorModel : PageModel
{
    public string? Message { get; set; }

    public bool ShowErrorMessage => !string.IsNullOrEmpty(Message);

    public void OnGet(string errorMessage)
    {
        Message = errorMessage;
    }
}
