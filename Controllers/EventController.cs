using Home_app.Models.Calendar;
using Home_app.Models.Calendar.Dto;
using Home_app.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace Home_app.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly IEventService _eventService;

        public EventController(IEventService eventService)
        {
            _eventService = eventService;
        }
        
        //POST
        [HttpPost]
        [ProducesResponseType(typeof(Event), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Event>> CreateEvent([FromBody] EventCreateDto @event)
        {
            return CreatedAtAction(nameof(CreateEvent), await _eventService.CreateEvent(@event));
        }
        
        // GET
        [HttpGet]
        public async Task<ActionResult<List<Event>>> GetAllEvents()
        {
            return Ok(await _eventService.GetAllEvents());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Event>> GetEventById(Guid id)
        {
            return Ok(await _eventService.GetEventById(id));
        }

        //PUT
        [HttpPut]
        public async Task<ActionResult<Event>> UpdateEvent(Guid id,[FromBody]  EventUpdateDto @event)
        {
            return Ok(await _eventService.UpdateEvent(id, @event));
        }
        
        //DELETE
        [HttpDelete]
        public async Task<ActionResult<Event>> DeleteEvent(Guid id)
        {
            return Ok(await _eventService.DeleteEvent(id));
        }
    }

}