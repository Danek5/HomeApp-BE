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

        /// <summary>
        /// Creates a new tag.
        /// </summary>
        /// <param name="tagCreateUpdateDto">Tag data to create.</param>
        /// <returns>The newly created tag.</returns>
        [HttpPost]
        [ProducesResponseType(typeof(Tag), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        public async Task<ActionResult<TagCreateUpdateDto>> CreateTag([FromBody] TagCreateUpdateDto tagCreateUpdateDto)
        {
            return CreatedAtAction(nameof(CreateTag), await _tagServices.CreateTag(tagCreateUpdateDto));
        }

        /// <summary>
        /// Retrieves all tags.
        /// </summary>
        /// <returns>List of all tags.</returns>
        [HttpGet]
        [ProducesResponseType(typeof(Tag), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        public async Task<ActionResult<IEnumerable<Tag>>> GetAllTags()
        {
            return Ok(await _tagServices.GetAllTags());
        }

        /// <summary>
        /// Retrieves a specific tag by its ID.
        /// </summary>
        /// <param name="id">ID of the tag.</param>
        /// <returns>The tag with the given ID.</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Tag), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        public async Task<ActionResult<Tag>> GetTagById(Guid id)
        {
            return Ok(await _tagServices.GetTagById(id));
        }

        /// <summary>
        /// Updates an existing tag by ID.
        /// </summary>
        /// <param name="id">ID of the tag to update.</param>
        /// <param name="tagCreateUpdateDto">Updated tag data.</param>
        /// <returns>The updated tag.</returns>
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(Tag), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        public async Task<ActionResult<Tag?>> UpdateTag(Guid id, [FromBody] TagCreateUpdateDto tagCreateUpdateDto)
        {
            return Ok(await _tagServices.UpdateTag(id, tagCreateUpdateDto));
        }

        /// <summary>
        /// Deletes a tag by its ID.
        /// </summary>
        /// <param name="id">ID of the tag to delete.</param>
        /// <returns>The deleted tag or null if not found.</returns>
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
