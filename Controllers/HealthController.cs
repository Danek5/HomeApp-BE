using Home_app.Models.Health;
using Home_app.Models.Health.Dto;
using Home_app.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Home_app.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class HealthController : ControllerBase
    {
        private readonly IHealthServices _healthServices;

        public HealthController(IHealthServices healthServices)
        {
            _healthServices = healthServices;
        }

        //POST
        [HttpPost]
        [ProducesResponseType(typeof(HealthRecord), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        public async Task<ActionResult<HealthRecord>> CreateRecord([FromBody] RecordCreateDto recordCreateDto)
        {
            return CreatedAtAction(nameof(CreateRecord), await _healthServices.CreateRecord(recordCreateDto));
        }
        
        
        //GET
        [HttpGet]
        [ProducesResponseType(typeof(HealthRecord), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        public async Task<ActionResult<List<HealthRecord>>> GetAllEvents()
        {
            return Ok(await _healthServices.GetAllRecords());
        }

        [HttpGet("/measurements")]
        [ProducesResponseType(typeof(HealthRecord), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        public async Task<ActionResult<IEnumerable<Measurement?>>> GetAllMeasurements()
        {
            return Ok(await _healthServices.GetAllMeasurements());
        }

        [HttpGet("/lifts")]
        [ProducesResponseType(typeof(HealthRecord), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        public async Task<ActionResult<IEnumerable<Lift?>>> GetAllLifts()
        {
            return Ok(await _healthServices.GetAllLifts());
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(HealthRecord), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        public async Task<ActionResult<HealthRecord>> GetRecordById(Guid id)
        {
            return Ok(await _healthServices.GetRecordById(id));
        }
        
        
        //PUT
        [HttpPut]
        [ProducesResponseType(typeof(HealthRecord), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        public async Task<ActionResult<HealthRecord?>> UpdateRecord(Guid id,[FromBody] RecordCreateDto healthRecord)
        {
            return Ok(await _healthServices.UpdateRecord(id, healthRecord));
        }
        
        [HttpPut("{id}/add_measurement")]
        [ProducesResponseType(typeof(HealthRecord), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        public async Task<ActionResult<HealthRecord>?> AddMeasurement(Guid id, [FromBody] MeasurementCreateDto measurementCreateDto)
        {
            return Ok(await _healthServices.AddMeasurement(id, measurementCreateDto));
        }
        
        [HttpPut("{id}/add_lift")]
        [ProducesResponseType(typeof(HealthRecord), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        public async Task<ActionResult<HealthRecord>?> AddLift(Guid id, [FromBody] LiftCreateDto liftCreateDto)
        {
            return Ok(await _healthServices.AddLift(id, liftCreateDto));
        }


        //DELETE
        [HttpDelete("record/{id}")]
        [ProducesResponseType(typeof(HealthRecord), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        public async Task<ActionResult<HealthRecord?>> DeleteRecord(Guid id)
        {
            return Ok(await _healthServices.DeleteRecord(id));
        }

        [HttpDelete("measurement/{measurementId}")]
        [ProducesResponseType(typeof(HealthRecord), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        public async Task<ActionResult<HealthRecord?>> DeleteMeasurement(Guid recordId, Guid measurementId)
        {
            return Ok(await _healthServices.DeleteMeasurement(recordId, measurementId));
        }

        [HttpDelete("lift/{liftId}")]
        [ProducesResponseType(typeof(HealthRecord), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        public async Task<ActionResult<HealthRecord?>> DeleteLift(Guid recordId, Guid liftId)
        {
            return Ok(await _healthServices.DeleteLift(recordId, liftId));
        }
        
    }
}