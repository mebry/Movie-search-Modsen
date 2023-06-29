using Film.BusinessLogic.DTOs.RequestDTOs;
using Film.BusinessLogic.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Film.API.Controllers.v1
{
    [Route("api/v{apiVersion:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    [ApiController]
    public class TagsController : ControllerBase
    {
        private readonly ITagService _tagService;

        public TagsController(ITagService tagService)
        {
            _tagService = tagService;
        }

        /// <summary>
        /// Creates a new tag.
        /// </summary>
        /// <param name="tag">The tag data.</param>
        /// <returns>The created tag.</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<IActionResult> CreateAsync([FromBody] TagRequestDTO tag)
        {
            var createdTag = await _tagService.CreateAsync(tag);

            return CreatedAtRoute("GetTagById", new { id = createdTag.Id }, createdTag);
        }

        /// <summary>
        /// Retrieves all tags.
        /// </summary>
        /// <returns>The list of tags.</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAsync()
        {
            var tags = await _tagService.GetAllAsync();

            return Ok(tags);
        }

        /// <summary>
        /// Retrieves a tag by Id.
        /// </summary>
        /// <param name="id">The Id of the tag.</param>
        /// <returns>The tag with the specified Id.</returns>
        [HttpGet("{id}", Name = "GetTagById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            var tag = await _tagService.GetByIdAsync(id);

            return Ok(tag);
        }

        /// <summary>
        /// Updates an existing tag.
        /// </summary>
        /// <param name="id">The Id of the tag.</param>
        /// <param name="tag">The updated tag data.</param>
        /// <returns>No content.</returns>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateAsync(Guid id, [FromBody] TagRequestDTO tag)
        {
            await _tagService.UpdateAsync(id, tag);

            return NoContent();
        }

        /// <summary>
        /// Deletes a tag.
        /// </summary>
        /// <param name="id">The ID of the tag to delete.</param>
        /// <returns>No content.</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            await _tagService.DeleteAsync(id);

            return NoContent();
        }
    }
}
