using Home_app.Models.Calendar;
using Home_app.Models.Calendar.Dto;

namespace Home_app.Services.Interfaces;

public interface IEventService
{
    Task<Event?> CreateEvent(EventCreateDto eventCreateDto);
    Task<IEnumerable<Event?>> GetAllEvents();
    Task<Event?> GetEventById(Guid id);
    Task<Event?> UpdateEvent(Guid id, EventUpdateDto eventUpdateDto);
    Task<Event?> DeleteEvent(Guid id);
}