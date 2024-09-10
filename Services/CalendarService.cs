using Home_app.Models.Calendar;
using Home_app.Models.Dto;
using Home_app.Repositories.Interfaces;
using Home_app.Services.Interfaces;

namespace Home_app.Services;

public class CalendarService : ICalendarService
{
    private readonly ICalendarRepository _calendarRepository;

    public CalendarService(ICalendarRepository calendarRepository)
    {
        _calendarRepository = calendarRepository;
    }
    


    public async Task<Event> CreateEvent(Event @event)
    {
        return await _calendarRepository.CreateEvent(@event);
    }

    public async Task<IEnumerable<Event?>> GetAllEvents()
    {
        var events = await _calendarRepository.GetAllEvents();
        return events;
    }

    public async Task<Event?> GetEventById(Guid id)
    {
        var @event = await _calendarRepository.GetEventById(id);
        return @event;
    }
}