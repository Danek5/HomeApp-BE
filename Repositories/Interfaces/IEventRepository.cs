using Home_app.Models.Calendar;

namespace Home_app.Repositories.Interfaces;

public interface IEventRepository
{
    Task<Event?> CreateEvent(Event @event);
    Task<IEnumerable<Event?>> GetAllEvents();
    Task<IEnumerable<Event?>> GetAllActiveEvents();
    Task<Event?> GetEventById(Guid id);
    Task<Event?> UpdateEvent(Event @event);
    Task<Event?> DeleteEvent(Event @event);
}