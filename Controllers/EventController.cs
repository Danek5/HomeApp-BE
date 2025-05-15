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

        /// <summary>
        /// Retrieves all events from the database.
        /// </summary>
        /// <returns>List of all events.</returns>
        [HttpGet]
        [ProducesResponseType(typeof(Event), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Event), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<Event>>> GetAllEvents()
        {
            return Ok(await _eventServices.GetAllEvents());
        }

        /// <summary>
        /// Retrieves a specific event by its ID.
        /// </summary>
        /// <param name="id">Event ID.</param>
        /// <returns>The event with the given ID.</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Event>> GetEventById(Guid id)
        {
            return Ok(await _eventServices.GetEventById(id));
        }

        /// <summary>
        /// Retrieves all events scheduled for a specific day.
        /// </summary>
        /// <param name="day">Day to filter events by.</param>
        /// <returns>List of events for the given day.</returns>
        [HttpGet("day")]
        public async Task<ActionResult<IEnumerable<Event>>> GetDayEvents(DateOnly day)
        {
            return Ok(await _eventServices.GetDayEvents(day));
        }

        /// <summary>
        /// Retrieves all events scheduled for a specific week.
        /// </summary>
        /// <param name="week">Start date of the week.</param>
        /// <returns>List of events for the given week.</returns>
        [HttpGet("week")]
        public async Task<ActionResult<IEnumerable<Event>>> GetWeekEvents(DateOnly week)
        {
            return Ok(await _eventServices.GetWeekEvents(week));
        }

        /// <summary>
        /// Retrieves all events scheduled for a specific month.
        /// </summary>
        /// <param name="month">First day of the month to filter by.</param>
        /// <returns>List of events for the given month.</returns>
        [HttpGet("month")]
        public async Task<ActionResult<IEnumerable<Event>>> GetMonthEvents(DateOnly month)
        {
            return Ok(await _eventServices.GetMonthEvents(month));
        }

        /// <summary>
        /// Creates a new event.
        /// </summary>
        /// <param name="event">Event data to create.</param>
        /// <returns>The newly created event.</returns>
        [HttpPost]
        [ProducesResponseType(typeof(Event), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        public async Task<ActionResult<Event>> CreateEvent([FromBody] EventCreateDto @event)
        {
            var createdEvent = await _eventServices.CreateEvent(@event);
            return CreatedAtAction(nameof(CreateEvent), createdEvent);
        }

        /// <summary>
        /// Creates multiple events in batch.
        /// </summary>
        /// <param name="events">List of events to create.</param>
        /// <returns>List of created events.</returns>
        [HttpPost("batch")]
        [ProducesResponseType(typeof(Event), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        public async Task<ActionResult<Event>> CreateEvents([FromBody] List<EventCreateDto> events)
        {
            var createdEvents = await _eventServices.CreateEvents(events);
            return CreatedAtAction(nameof(CreateEvent), createdEvents);
        }

        /// <summary>
        /// Updates an existing event by ID.
        /// </summary>
        /// <param name="id">ID of the event to update.</param>
        /// <param name="event">Updated event data.</param>
        /// <returns>The updated event.</returns>
        [HttpPut("{id}")]
        public async Task<ActionResult<Event>> UpdateEvent(Guid id, [FromBody] EventUpdateDto @event)
        {
            return Ok(await _eventServices.UpdateEvent(id, @event));
        }

        /// <summary>
        /// Assigns a tag to a specific event.
        /// </summary>
        /// <param name="eventId">ID of the event.</param>
        /// <param name="tagId">ID of the tag to assign.</param>
        /// <returns>The updated event with the assigned tag.</returns>
        [HttpPut("{eventId}/assign/{tagId}")]
        public async Task<ActionResult<Event>> AssignTag(Guid eventId, Guid tagId)
        {
            return Ok(await _eventServices.AssignTag(eventId, tagId));
        }

        /// <summary>
        /// Removes a tag from a specific event.
        /// </summary>
        /// <param name="eventId">ID of the event.</param>
        /// <param name="tagId">ID of the tag to remove.</param>
        /// <returns>The updated event with the tag removed.</returns>
        [HttpPut("{eventId}/unassign/{tagId}")]
        public async Task<ActionResult<Event>> UnassignTag(Guid eventId, Guid tagId)
        {
            return Ok(await _eventServices.UnassignTag(eventId, tagId));
        }

        /// <summary>
        /// Deletes a specific event by its ID.
        /// </summary>
        /// <param name="id">ID of the event to delete.</param>
        /// <returns>The deleted event data.</returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult<Event>> DeleteEvent(Guid id)
        {
            return Ok(await _eventServices.DeleteEvent(id));
        }
    }
}
