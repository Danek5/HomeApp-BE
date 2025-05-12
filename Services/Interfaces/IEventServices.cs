using Home_app.Models.Calendar;
using Home_app.Models.Calendar.Dto;

namespace Home_app.Services.Interfaces;

public interface IEventServices
{
    Task<IEnumerable<Event?>> GetAllEvents();
    Task<Event?> GetEventById(Guid id);
    Task<IEnumerable<Event?>> GetDayEvents(DateOnly? day);
    Task<IEnumerable<Event?>> GetWeekEvents(DateOnly? week);
    Task<IEnumerable<Event?>> GetMonthEvents(DateOnly? month);
    
    Task<Event?> CreateEvent(EventCreateDto eventCreateDto);
    
    Task<List<Event?>> CreateEvents(List<EventCreateDto> eventCreateDto);
    Task<Event?> UpdateEvent(Guid id, EventUpdateDto eventUpdateDto);
    Task<Event?> AssignTag(Guid eventId, Guid tagId);
    Task<Event?> UnassignTag(Guid eventId, Guid tagId);
    Task<Event?> DeleteEvent(Guid id);
    Task ArchiveExpiredEvents();
}