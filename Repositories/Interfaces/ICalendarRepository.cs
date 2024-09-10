using Home_app.Models.Calendar;

namespace Home_app.Repositories.Interfaces;

public interface ICalendarRepository
{
    Task<Event> CreateEvent(Event @event);
    Task<IEnumerable<Event?>> GetAllEvents();
    Task<Event?> GetEventById(Guid id);
    Task<Event> EditEvent(Event @event);
    Task<Event> DeleteEvent(Event @event);
}