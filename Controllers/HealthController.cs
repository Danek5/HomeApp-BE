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
        public async Task<ActionResult<HealthRecord>> CreateRecord([FromBody] RecordCreateDto recordCreateDto)
        {
            return CreatedAtAction(nameof(CreateRecord), await _healthServices.CreateRecord(recordCreateDto));
        }
        
        
        //GET
        [HttpGet]
        public async Task<ActionResult<List<HealthRecord>>> GetAllEvents()
        {
            return Ok(await _healthServices.GetAllRecords());
        }
    }
}