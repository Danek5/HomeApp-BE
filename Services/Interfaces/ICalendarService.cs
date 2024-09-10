using Home_app.Models.Calendar;

namespace Home_app.Services.Interfaces;

public interface ICalendarService
{
    Task<Event> CreateEvent(Event @event);
    Task<IEnumerable<Event?>> GetAllEvents();
    Task<Event?> GetEventById(Guid id);
}