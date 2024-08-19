﻿using HabitTracker.Application.Services;
using HabitTracker.Domain.Entities;
using HabitTracker.WebUI.Models;

namespace HabitTracker.WebUI.Controllers;

public class HabitLogController : IHabitLogController
{
    private readonly IHabitLogService _service;

    public HabitLogController(IHabitLogService service)
    {
        _service = service;
    }

    public bool AddHabitLog(CreateHabitLogRequest request)
    {
        var habitLog = new HabitLog
        {
            Id = request.Id,
            HabitId = request.HabitId,
            Date = request.Date,
            Quantity = request.Quantity,
        };

        var result = _service.AddHabitLog(habitLog);
        return result > 0;
    }

    public bool DeleteHabitLog(Guid id)
    {
        var habitLog = _service.GetHabitLog(id);
        if (habitLog is null)
        {
            return false;
        }

        var result = _service.DeleteHabitLog(habitLog.Id);
        return result > 0;
    }

    public HabitLogDto? GetHabitLog(Guid id)
    {
        var habitLog = _service.GetHabitLog(id);
        return habitLog is null ? null : new HabitLogDto(habitLog);
    }

    public IReadOnlyList<HabitLogDto> GetHabitLogs()
    {
        return _service.GetHabitLogs()
            .Select(x => new HabitLogDto(x))
            .OrderBy(o => o.Date)
            .ToList();
    }

    public IReadOnlyList<HabitLogDto> GetHabitLogs(Guid habitId)
    {
        return _service.GetHabitLogs(habitId)
            .Select(x => new HabitLogDto(x))
            .OrderBy(o => o.Date)
            .ToList();
    }

    public IReadOnlyList<HabitLogDto> GetHabitLogsByDateRange(DateTime from, DateTime to)
    {
        return _service.GetHabitLogsByDateRange(from, to)
            .Select(x => new HabitLogDto(x))
            .OrderBy(o => o.Date)
            .ToList();
    }

    public IReadOnlyList<HabitLogDto> GetHabitLogsByDateRange(Guid habitId, DateTime from, DateTime to)
    {
        return _service.GetHabitLogsByDateRange(habitId, from, to)
            .Select(x => new HabitLogDto(x))
            .OrderBy(o => o.Date)
            .ToList();
    }

    public bool UpdateHabitLog(UpdateHabitLogRequest request)
    {
        var habitLog = _service.GetHabitLog(request.Id);
        if (habitLog is null)
        {
            return false;
        }

        habitLog.Date = request.Date;
        habitLog.Quantity = request.Quantity;

        var result = _service.UpdateHabitLog(habitLog);
        return result > 0;
    }
}
