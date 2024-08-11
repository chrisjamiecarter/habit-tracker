using System.Globalization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.Sqlite;
using WaterLogger.UI.Models;

namespace WaterLogger.UI.Pages;
public class IndexModel : PageModel
{
    private readonly IConfiguration _configuration;

    public IndexModel(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public List<DrinkingWater> Records { get; set; }

    public void OnGet()
    {
        Records = GetDrinkingWaters();
        ViewData["Total"] = Records.Sum(x => x.Quantity);
    }

    private List<DrinkingWater> GetDrinkingWaters()
    {
        List<DrinkingWater> output = [];

        using var connection = new SqliteConnection(_configuration.GetConnectionString("Default"));
        connection.Open();
        using var command = connection.CreateCommand();
        command.CommandText = $"SELECT * FROM drinking_water;";
        using var reader = command.ExecuteReader();
        while (reader.Read())
        {
            output.Add(new DrinkingWater
            {
                Id = reader.GetInt32(0),
                Date = DateTime.Parse(reader.GetString(1), CultureInfo.CurrentCulture.DateTimeFormat),
                Quantity = reader.GetInt32(2),
            });
        }
        connection.Close();

        return output;
    }
}
