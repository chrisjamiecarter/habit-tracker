using System.ComponentModel;
using HabitTracker.Domain.Entities;
using HabitTracker.WebUI.Controllers;
using HabitTracker.WebUI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HabitTracker.WebUI.Pages
{
    public class ViewHabitLogsModel : PageModel
    {
        private readonly IHabitLogController _habitLogController;

        public ViewHabitLogsModel(IHabitLogController habitLogController)
        {
            _habitLogController = habitLogController;
        }

        public Guid HabitId { get; set; }

        public IReadOnlyList<HabitLogDto> HabitLogs { get; set; } = [];

        public void OnGet(Guid habitId)
        {
            HabitId = habitId;
            HabitLogs = GetHabitLogs(habitId);
            //ViewData["Total"] = Habits.Sum(x => x.Quantity);
            ViewData["HabitLogsCount"] = HabitLogs.Count;
        }

        private IReadOnlyList<HabitLogDto> GetHabitLogs(Guid habitId)
        {
            return _habitLogController.GetHabitLogs(habitId);
        }
    }
}
