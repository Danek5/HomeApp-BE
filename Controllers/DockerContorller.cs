using Microsoft.AspNetCore.Mvc;
using Docker.DotNet.Models;
using Home_app.Services;

namespace Home_app.Controllers
{
  /*  [Route("[controller]")]
    [ApiController]
    
    public class DockerController : ControllerBase
    {
        private readonly DockerService _dockerService;

        public DockerController(DockerService dockerService)
        {
            _dockerService = dockerService;
        }

        [HttpGet("containers")]
        public async Task<ActionResult<IEnumerable<ContainerListResponse>>> GetRunningContainers()
        {
            var containers = await _dockerService.GetRunningContainers();
            return Ok(containers);
        }

        [HttpGet("containers/{id}/logs")]
        public async Task<ActionResult<string>> GetContainerLogs(string id)
        {
            var logs = await _dockerService.GetContainerLogs(id);
            return Ok(logs);
        }


        
        [HttpGet("containers/{id}")]
        public async Task<ActionResult<ContainerListResponse>> GetContainerDetails(string id)
        {
            var containerDetails = await _dockerService.GetContainerDetails(id);
            return Ok(containerDetails);
        }
    }*/
}