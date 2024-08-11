using System.Globalization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.Sqlite;
using WaterLogger.UI.Models;

namespace WaterLogger.UI.Pages;

public class UpdateModel : PageModel
{
    private readonly IConfiguration _configuration;

    public UpdateModel(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    [BindProperty]
    public DrinkingWater? DrinkingWater { get; set; }

    public IActionResult OnGet(int id)
    {
        DrinkingWater = GetById(id);
        return Page();
    }

    private DrinkingWater? GetById(int id)
    {
        using var connection = new SqliteConnection(_configuration.GetConnectionString("Default"));
        connection.Open();
        using var command = connection.CreateCommand();
        command.CommandText = $"SELECT * FROM drinking_water WHERE Id = {id};";
        using var reader = command.ExecuteReader();
        if (reader.Read())
        {
            return new DrinkingWater
            {
                Id = reader.GetInt32(0),
                Date = DateTime.Parse(reader.GetString(1), CultureInfo.CurrentCulture.DateTimeFormat),
                Quantity = reader.GetInt32(2),
            };
        }
        connection.Close();

        return null;
    }

    public IActionResult OnPost()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        if (DrinkingWater is null)
        {
            return BadRequest();
        }

        using var connection = new SqliteConnection(_configuration.GetConnectionString("Default"));
        connection.Open();
        using var command = connection.CreateCommand();
        command.CommandText = $"UPDATE drinking_water SET Date = '{DrinkingWater.Date}', Quantity = {DrinkingWater.Quantity} WHERE Id = {DrinkingWater.Id};";
        command.ExecuteNonQuery();
        connection.Close();

        return RedirectToPage("./Index");
    }
}
