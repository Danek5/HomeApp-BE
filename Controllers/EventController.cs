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
        [HttpPost]
        [ProducesResponseType(typeof(Event), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        public async Task<ActionResult<Event>> CreateEvent([FromBody] EventCreateDto @event)
        {
            return CreatedAtAction(nameof(CreateEvent), await _eventServices.CreateEvent(@event));
        }
        
        
        // GET
        [HttpGet]
        [ProducesResponseType(typeof(Event),StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Event),StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<Event>>> GetAllEvents()
        {
            return Ok(await _eventServices.GetAllEvents());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Event>> GetEventById(Guid id)
        {
            return Ok(await _eventServices.GetEventById(id));
        }
        
        [HttpGet("day")]
        public async Task<ActionResult<IEnumerable<Event>>> GetDayEvents(DateOnly day)
        {
            return Ok(await _eventServices.GetDayEvents(day));
        }

        [HttpGet("week")]
        public async Task<ActionResult<IEnumerable<Event>>> GetWeekEvents(DateOnly week)
        {
            return Ok(await _eventServices.GetWeekEvents(week));
        }
        
        //PUT
        [HttpPut]
        public async Task<ActionResult<Event>> UpdateEvent(Guid id,[FromBody] EventUpdateDto @event)
        {
            return Ok(await _eventServices.UpdateEvent(id, @event));
        }

        [HttpPut("{eventId}/assign/{tagId}")]
        public async Task<ActionResult<Event>> AssignTag(Guid eventId, Guid tagId)
        {
            return Ok(await _eventServices.AssignTag(eventId, tagId));
        }
        
        [HttpPut("{eventId}/unassign/{tagId}")]
        public async Task<ActionResult<Event>> UnassignTag(Guid eventId, Guid tagId)
        {
            return Ok(await _eventServices.UnassignTag(eventId, tagId));
        }
        
        
        //DELETE
        [HttpDelete]
        public async Task<ActionResult<Event>> DeleteEvent(Guid id)
        {
            return Ok(await _eventServices.DeleteEvent(id));
        }
    }

}