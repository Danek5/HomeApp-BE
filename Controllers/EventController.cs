using Home_app.Models.Calendar;
using Home_app.Models.Calendar.Dto;
using Home_app.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Home_app.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly IEventServices _eventServices;

        public EventController(IEventServices eventServices)
        {
            _eventServices = eventServices;
        }
        
        
        //POST
        /// <summary>
        /// 
        /// </summary>
        /// <param name="event"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(Event), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        public async Task<ActionResult<Event>> CreateEvent([FromBody] EventCreateDto @event)
        {
            var createdEvent = await _eventServices.CreateEvent(@event);
            
            return CreatedAtAction(nameof(CreateEvent), createdEvent);
        }
        
        
        // GET
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(Event),StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Event),StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<Event>>> GetAllEvents()
        {
            return Ok(await _eventServices.GetAllEvents());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Event>> GetEventById(Guid id)
        {
            return Ok(await _eventServices.GetEventById(id));
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="day"></param>
        /// <returns></returns>
        [HttpGet("day")]
        public async Task<ActionResult<IEnumerable<Event>>> GetDayEvents(DateOnly day)
        {
            return Ok(await _eventServices.GetDayEvents(day));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="week"></param>
        /// <returns></returns>
        [HttpGet("week")]
        public async Task<ActionResult<IEnumerable<Event>>> GetWeekEvents(DateOnly week)
        {
            return Ok(await _eventServices.GetWeekEvents(week));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="month"></param>
        /// <returns></returns>
        [HttpGet("month")]
        public async Task<ActionResult<IEnumerable<Event>>> GetMonthEvents(DateOnly month)
        {
            return Ok(await _eventServices.GetMonthEvents(month));
        }
        
        
        
        //PUT
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="event"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<ActionResult<Event>> UpdateEvent(Guid id,[FromBody] EventUpdateDto @event)
        {
            return Ok(await _eventServices.UpdateEvent(id, @event));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="eventId"></param>
        /// <param name="tagId"></param>
        /// <returns></returns>
        [HttpPut("{eventId}/assign/{tagId}")]
        public async Task<ActionResult<Event>> AssignTag(Guid eventId, Guid tagId)
        {
            return Ok(await _eventServices.AssignTag(eventId, tagId));
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="eventId"></param>
        /// <param name="tagId"></param>
        /// <returns></returns>
        [HttpPut("{eventId}/unassign/{tagId}")]
        public async Task<ActionResult<Event>> UnassignTag(Guid eventId, Guid tagId)
        {
            return Ok(await _eventServices.UnassignTag(eventId, tagId));
        }
        
        
        //DELETE
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult<Event>> DeleteEvent(Guid id)
        {
            return Ok(await _eventServices.DeleteEvent(id));
        }
    }

}