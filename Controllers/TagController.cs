using Home_app.Models.Calendar;
using Home_app.Models.Calendar.Dto;
using Home_app.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Home_app.Controllers
{
    [Route("[controller]")]
    [ApiController]
    
    public class TagController : ControllerBase
    {
        private readonly ITagServices _tagServices;

        public TagController(ITagServices tagService)
        {
            _tagServices = tagService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(Tag), StatusCodes.Status201Created)]

        public async Task<ActionResult<Tag>> CreateTag(TagCreateUpdateDto tagCreateUpdateDto)
        {
            return Ok(await _tagServices.CreateTag(tagCreateUpdateDto));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tag>>> GetAllTags()
        {
            return Ok(await _tagServices.GetAllTags());
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<Tag>> GetTagById(Guid id)
        {
            return Ok(await _tagServices.GetTagById(id));
        }
    }
}