using Home_app.DBContext;
using Home_app.Models.Calendar;
using Home_app.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Home_app.Repositories;

public class EventRepository : IEventRepository
{
    private readonly HomeAppContext _homeAppContext;

    public EventRepository(HomeAppContext homeAppContext)
    {
        _homeAppContext = homeAppContext;
    }

    public async Task<Event?> CreateEvent(Event @event)
    {
        await _homeAppContext.Events.AddAsync(@event);
        await _homeAppContext.SaveChangesAsync();
        return @event;
    }

    public async Task<IEnumerable<Event?>> GetAllEvents()
    {
        return await _homeAppContext.Events.Include(e => e.Tags).ToListAsync();
    }

    public async Task<Event?> GetEventById(Guid id)
    {
        return await _homeAppContext.Events.Include(e => e.Tags).FirstOrDefaultAsync(e => e.Id == id);
    }

    public async Task<Event?> UpdateEvent(Event @event)
    {
        _homeAppContext.Events.Update(@event);
        await _homeAppContext.SaveChangesAsync();
        return @event;
    }

    public async Task<Event?> DeleteEvent(Event @event)
    {
        _homeAppContext.Events.Remove(@event);
        await _homeAppContext.SaveChangesAsync();
        return @event;
    }
}