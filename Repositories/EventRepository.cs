using Home_app.DBContext;
using Home_app.Models.Calendar;
using Home_app.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Home_app.Repositories;

public class EventRepository : RepositoryBase<Event>, IEventRepository
{
    public EventRepository(HomeAppContext context) : base(context)
    {
    }

    public Event? CreateEvent(Event @event)
    {
        return Create(@event);
    }

    public async Task<IEnumerable<Event>> GetAllEvents()
    {
        return await GetAll().ToListAsync();
    }
    
    public async Task<IEnumerable<Event?>> GetAllActiveEvents()
    {
        return await GetByCondition(e => e.Archived == false).ToListAsync();
    }

    public async Task<Event?> GetEventById(Guid id)
    {
        return await GetByCondition(e => e.Id == id).FirstOrDefaultAsync();
    }

    public Event? UpdateEvent(Event @event)
    {
        return  Update(@event);
    }

    public Event? DeleteEvent(Event @event)
    {
        return Delete(@event);
    }
}