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
    private readonly IEventRepository _eventRepository;
    private readonly ITagRepository _tagRepository;
    private readonly IMapper _mapper;

    public EventServices(IEventRepository eventRepository, ITagRepository tagRepository, IMapper mapper)
    {
        _eventRepository = eventRepository;
        _tagRepository = tagRepository;
        _mapper = mapper;
    }
    

    public async Task<Event?> CreateEvent(EventCreateDto eventCreateDto)
    {
        if (eventCreateDto == null)
        {
            Log.Information("User creation fail");
            return null;
        }

        var eventCreate = _mapper.Map<Event>(eventCreateDto);
        return await _eventRepository.CreateEvent(eventCreate);
    }

    public async Task<IEnumerable<Event?>> GetAllEvents()
    {
        return await _eventRepository.GetAllEvents();
    }

    public async Task<Event?> GetEventById(Guid id)
    {
        return await _eventRepository.GetEventById(id);
    }
    
    public async Task<IEnumerable<Event?>> GetDayEvents(DateOnly? day)
    {
        if (day == null || day == DateOnly.MinValue)
        {
            day = DateOnly.FromDateTime(DateTime.Now);
        }
  
        var allEvents = await _eventRepository.GetAllActiveEvents();
        
        var dayEvents = allEvents
            .Where(evt => evt != null && IsEventOnDay(evt, day.Value))
            .ToList();
    
        return dayEvents;
    }

    public async Task<IEnumerable<Event?>> GetWeekEvents(DateOnly? week)
    {
        if (week == null || week == DateOnly.MinValue)
        {
            week = DateOnly.FromDateTime(DateTime.Now);
        }

        var allEvents = await _eventRepository.GetAllActiveEvents();
        
        var weekEndTime = week.Value.AddDays(7);
        
        var weekEvents = allEvents
            .Where(evt => evt != null && IsEventInWeek(evt, week.Value, weekEndTime))
            .ToList();
        
        return weekEvents;
    }

    private bool IsEventInWeek(Event evt, DateOnly start, DateOnly end)
    {
        var occurrence = DateOnly.FromDateTime(evt.DateTime);

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

    private bool IsEventOnDay(Event evt, DateOnly targetDay)
    {
        var occurrence = DateOnly.FromDateTime(evt.DateTime);

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
                return evt.DateTime.Date == targetDay.ToDateTime(new TimeOnly());
        }

        return false;
    }

    
    public async Task<Event?> UpdateEvent(Guid id, EventUpdateDto eventUpdateDto)
    {
        var updateEvent = await _eventRepository.GetEventById(id);
        if (eventUpdateDto == null || updateEvent == null)
        {
            return null;
        }
        
        _mapper.Map(eventUpdateDto, updateEvent);
        
        return await _eventRepository.UpdateEvent(updateEvent);
    }

    public async Task<Event?> AssignTag(Guid eventId, Guid tagId)
    {
        var @event = await _eventRepository.GetEventById(eventId);
        var tag = await _tagRepository.GetTagById(tagId);
        
        if (@event == null || tag == null)
        {
            return null;
        }

        @event.Tags.Add(tag);
        await _eventRepository.UpdateEvent(@event);
        
        return await _eventRepository.UpdateEvent(@event);
    }

    public async Task<Event?> UnassignTag(Guid eventId, Guid tagId)
    {
        var @event = await _eventRepository.GetEventById(eventId);
        var tag = await _tagRepository.GetTagById(tagId);
        
        if (@event == null || tag == null)
        {
            return null;
        }

        @event.Tags.Remove(tag);
        await _eventRepository.UpdateEvent(@event);

        return await _eventRepository.UpdateEvent(@event);
    }

    public async Task<Event?> DeleteEvent(Guid id)
    {
        var even = await _eventRepository.GetEventById(id);
        return await _eventRepository.DeleteEvent(even!);
    }

    public async Task ArchiveExpiredEvents()
    {
        var allEvents = await _eventRepository.GetAllEvents();

        foreach (var evt in allEvents)
        {
            if (evt?.Frequency != 0 || evt.DateTime > DateTime.UtcNow || evt.Archived) continue;
            evt.Archived = true;
            await _eventRepository.UpdateEvent(evt);
        }
    }
}