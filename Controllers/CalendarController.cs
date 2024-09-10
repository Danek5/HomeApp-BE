using Home_app.Models.Calendar;
using Home_app.Repositories.Interfaces;
using Home_app.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Home_app.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CalendarController : ControllerBase
    {
        private readonly ICalendarRepository _calendarRepository;
        private readonly ICalendarService _calendarService;
        
        
            // GET
            [HttpGet]
            public async Task<ActionResult<List<Event>>> GetAllEvents()
            {
                var events = await _calendarService.GetAllEvents();

                return Ok(events);
            }
    }

}