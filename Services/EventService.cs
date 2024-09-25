
using AutoMapper;
using Home_app.Models.Calendar;
using Home_app.Models.Calendar.Dto;
using Home_app.Repositories.Interfaces;
using Home_app.Services.Interfaces;
using Serilog;

namespace Home_app.Services;

public class EventService : IEventService
{
    private readonly IEventRepository _eventRepository;
    private readonly ITagRepository _tagRepository;
    private readonly IMapper _mapper;

    public EventService(IEventRepository eventRepository, ITagRepository tagRepository, IMapper mapper)
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
}