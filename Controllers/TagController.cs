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

        //POST
        /// <summary>
        /// 
        /// </summary>
        /// <param name="tagCreateUpdateDto"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(Tag), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        public async Task<ActionResult<TagCreateUpdateDto>> CreateTag([FromBody]TagCreateUpdateDto tagCreateUpdateDto)
        {
            return CreatedAtAction(nameof(CreateTag), await _tagServices.CreateTag(tagCreateUpdateDto));
        }

        //GET
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(Tag), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        public async Task<ActionResult<IEnumerable<Tag>>> GetAllTags()
        {
            return Ok(await _tagServices.GetAllTags());
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Tag), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        public async Task<ActionResult<Tag>> GetTagById(Guid id)
        {
            return Ok(await _tagServices.GetTagById(id));
        }
        
        //PUT
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="tagCreateUpdateDto"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(Tag), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        public async Task<ActionResult<Tag?>> UpdateTag(Guid id,[FromBody] TagCreateUpdateDto tagCreateUpdateDto)
        {
            return Ok(await _tagServices.UpdateTag(id, tagCreateUpdateDto));
        }

        //DELETE
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(Tag), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        public async Task<ActionResult<Tag?>> DeleteTag(Guid id)
        {
            return Ok(await _tagServices.DeleteTag(id));
        }
    }
}