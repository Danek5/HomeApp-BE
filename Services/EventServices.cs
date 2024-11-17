using AutoMapper;
using Home_app.Models.Calendar;
using Home_app.Models.Calendar.Dto;
using Home_app.Models.Calendar.Enums;
using Home_app.Repositories.Interfaces;
using Home_app.Services.Interfaces;
using Serilog;

namespace Home_app.Services;

public class EventServices : IEventServices
{
    private IRepositoryWrapper _repository;
    private readonly IMapper _mapper;

    public EventServices(IRepositoryWrapper repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<Event?> CreateEvent(EventCreateDto eventCreateDto)
    {
        if (eventCreateDto == null)
        {
            Log.Information("Event creation failed");
            return null;
        }

        var eventCreate = _mapper.Map<Event>(eventCreateDto);
        var even = _repository.Event.CreateEvent(eventCreate);
        await _repository.SaveAsync();
        return even;
    }

    public async Task<IEnumerable<Event?>> GetAllEvents()
    {
        return await _repository.Event.GetAllEvents();
    }

    public async Task<Event?> GetEventById(Guid id)
    {
        return await _repository.Event.GetEventById(id);
    }

    public async Task<IEnumerable<Event?>> GetDayEvents(DateOnly? day)
    {
        if (day == null || day == DateOnly.MinValue)
        {
            day = DateOnly.FromDateTime(DateTime.Now);
        }

        var allEvents = await _repository.Event.GetAllActiveEvents();

        var dayEvents = allEvents
            .Where(evt => evt != null && IsEventInDay(evt, day.Value))
            .ToList();

        return dayEvents;
    }

    public async Task<IEnumerable<Event?>> GetWeekEvents(DateOnly? week)
    {
        if (week == null || week == DateOnly.MinValue)
        {
            week = DateOnly.FromDateTime(DateTime.Now);
        }

        var allEvents = await _repository.Event.GetAllActiveEvents();
        
        var weekEndTime = week.Value.AddDays(7);

        var weekEvents = allEvents
            .Where(evt => IsEventInWeek(evt, week.Value, weekEndTime))
            .ToList();

        return weekEvents;
    }

    public async Task<IEnumerable<Event?>> GetMonthEvents(DateOnly? month)
    {
        if (month == null || month == DateOnly.MinValue)
        {
            month = DateOnly.FromDateTime(DateTime.Now);
        }

        var startOfMonth = new DateOnly(month.Value.Year, month.Value.Month, 1);
        var endOfMonth = startOfMonth.AddMonths(1).AddDays(-1);

        var allEvents = await _repository.Event.GetAllActiveEvents();

        var monthEvents = allEvents
            .Where(evt => IsEventInMonth(evt, startOfMonth, endOfMonth))
            .ToList();

        return monthEvents;
    }

    
    private bool IsEventInDay(Event evt, DateOnly targetDay)
    {
        var occurrence = evt.Date;

        switch (evt.Frequency)
        {
            case Frequency.Week:
                while (occurrence <= targetDay)
                {
                    if (occurrence == targetDay)
                    {
                        return true;
                    }
                    occurrence = occurrence.AddDays(7);
                }
                break;

            case Frequency.TwoWeek:
                while (occurrence <= targetDay)
                {
                    if (occurrence == targetDay)
                    {
                        return true;
                    }
                    occurrence = occurrence.AddDays(14);
                }
                break;

            case Frequency.Month:
                while (occurrence <= targetDay)
                {
                    if (occurrence == targetDay)
                    {
                        return true;
                    }
                    occurrence = occurrence.AddMonths(1);
                }
                break;

            case Frequency.Year:
                while (occurrence <= targetDay)
                {
                    if (occurrence == targetDay)
                    {
                        return true;
                    }
                    occurrence = occurrence.AddYears(1);
                }
                break;

            case Frequency.None:
                return evt.Date == targetDay;
        }

        return false;
    }
    
    private bool IsEventInWeek(Event evt, DateOnly start, DateOnly end)
    {
        var occurrence = evt.Date;

        switch (evt.Frequency)
        {
            case Frequency.None:
                if (occurrence >= start && occurrence <= end) return true;
                break;

            case Frequency.Week:
                return true;

            case Frequency.TwoWeek:
                while (occurrence <= end)
                {
                    if (occurrence >= start && occurrence <= end)
                    {
                        return true;
                    }
                    occurrence = occurrence.AddDays(14);
                }
                break;

            case Frequency.Month:
                while (occurrence <= end)
                {
                    if (occurrence >= start && occurrence <= end)
                    {
                        return true;
                    }
                    occurrence = occurrence.AddMonths(1);
                }
                break;

            case Frequency.Year:
                while (occurrence <= end)
                {
                    if (occurrence >= start && occurrence <= end)
                    {
                        return true;
                    }
                    occurrence = occurrence.AddYears(1);
                }
                break;

            default:
                return false;
        }

        return false;
    }
    
    private bool IsEventInMonth(Event evt, DateOnly start, DateOnly end)
    {
        var occurrence = evt.Date;

        switch (evt.Frequency)
        {
            case Frequency.None:
                if (occurrence >= start && occurrence <= end) return true;
                break;

            case Frequency.Week:
                return true;

            case Frequency.TwoWeek:
                while (occurrence <= end)
                {
                    if (occurrence >= start && occurrence <= end)
                    {
                        return true;
                    }
                    occurrence = occurrence.AddDays(14);
                }
                break;

            case Frequency.Month:
                while (occurrence <= end)
                {
                    if (occurrence >= start && occurrence <= end)
                    {
                        return true;
                    }
                    occurrence = occurrence.AddMonths(1);
                }
                break;

            case Frequency.Year:
                while (occurrence <= end)
                {
                    if (occurrence >= start && occurrence <= end)
                    {
                        return true;
                    }
                    occurrence = occurrence.AddYears(1);
                }
                break;

            default:
                return false;
        }

        return false;
    }
    
    public async Task<Event?> UpdateEvent(Guid id, EventUpdateDto eventUpdateDto)
    {
        var updateEvent = await _repository.Event.GetEventById(id);
        if (eventUpdateDto == null || updateEvent == null)
        {
            return null;
        }

        _mapper.Map(eventUpdateDto, updateEvent);
        var even = _repository.Event.UpdateEvent(updateEvent);
        await _repository.SaveAsync();
        return even;
    }

    public async Task<Event?> AssignTag(Guid eventId, Guid tagId)
    {
        var @event = await _repository.Event.GetEventById(eventId);
        var tag = await _repository.Tag.GetTagById(tagId);

        if (@event == null || tag == null)
        {
            return null;
        }

        @event.Tags.Add(tag); 
        _repository.Event.UpdateEvent(@event);
        var even = _repository.Event.UpdateEvent(@event);
        
        await _repository.SaveAsync();
        return even;
    }

    public async Task<Event?> UnassignTag(Guid eventId, Guid tagId)
    {
        var @event = await _repository.Event.GetEventById(eventId);
        var tag = await _repository.Tag.GetTagById(tagId);

        if (@event == null || tag == null)
        {
            return null;
        }

        @event.Tags.Remove(tag);
        _repository.Event.UpdateEvent(@event);
        var even = _repository.Event.UpdateEvent(@event);

        await _repository.SaveAsync();
        return even;
    }

    public async Task<Event?> DeleteEvent(Guid id)
    {
        var eventEntity = await _repository.Event.GetEventById(id);
        if (eventEntity == null) return null;
        var even = _repository.Event.DeleteEvent(eventEntity);

        await _repository.SaveAsync();
        return even;
    }

    public async Task ArchiveExpiredEvents()
    {
        var allEvents = await _repository.Event.GetAllEvents();

        foreach (var evt in allEvents)
        {
            if (evt?.Frequency == Frequency.None && evt.Date.ToDateTime(new TimeOnly()) <= DateTime.UtcNow && !evt.Archived)
            {
                evt.Archived = true;
                _repository.Event.UpdateEvent(evt);
            }
        }

        await _repository.SaveAsync();
    }
}
