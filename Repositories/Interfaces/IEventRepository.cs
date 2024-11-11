using Home_app.Models.Calendar;

namespace Home_app.Repositories.Interfaces;

public interface IEventRepository
{
    Task<IEnumerable<Event?>> GetAllEvents();
    Task<IEnumerable<Event?>> GetAllActiveEvents();
    Task<Event?> GetEventById(Guid id);
    Event? CreateEvent(Event @event);
    Event? UpdateEvent(Event @event);
    Event? DeleteEvent(Event @event);
}