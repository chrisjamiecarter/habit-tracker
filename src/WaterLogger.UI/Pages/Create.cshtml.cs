using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.Sqlite;
using WaterLogger.UI.Models;

namespace WaterLogger.UI.Pages;

public class CreateModel : PageModel
{
    private readonly IConfiguration _configuration;

    public CreateModel(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public IActionResult OnGet()
    {
        return Page();
    }

    [BindProperty]
    public DrinkingWater DrinkingWater { get; set; }

    public IActionResult OnPost()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        using var connection = new SqliteConnection(_configuration.GetConnectionString("Default"));
        connection.Open();
        using var command = connection.CreateCommand();
        command.CommandText = $"INSERT INTO drinking_water(date, quantity) VALUES ('{DrinkingWater.Date}', {DrinkingWater.Quantity});";
        command.ExecuteNonQuery();
        connection.Close();

        return RedirectToPage("./Index");
    }
}
