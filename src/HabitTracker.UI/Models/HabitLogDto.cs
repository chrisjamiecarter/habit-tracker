using System.ComponentModel.DataAnnotations;
using HabitTracker.Domain.Entities;

namespace HabitTracker.WebUI.Models;

public class HabitLogDto
{
    #region Constructor

    public HabitLogDto()
    {
    }

    public HabitLogDto(HabitLog model)
    {
        Id = model.Id;
        HabitId = model.HabitId;
        Date = model.Date;
        Quantity = model.Quantity;
    }

    #endregion
    #region Properties

    public Guid Id { get; set; }

    public Guid HabitId { get; set; }

    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    public DateTime Date { get; set; }

    public int Quantity { get; set; }

    #endregion
}
