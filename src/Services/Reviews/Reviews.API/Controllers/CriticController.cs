using Microsoft.AspNetCore.Mvc;
using Reviews.BusinessLogic.DTOs;
using Reviews.BusinessLogic.Services.Interfaces;

namespace Reviews.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CriticController : ControllerBase
    {
        private readonly ICriticService _criticService;

        public CriticController(ICriticService criticService)
        {
            _criticService = criticService;
        }

        /// <summary>
        /// Creates a new critic.
        /// </summary>
        /// <param name="requestCriticDTO">The critic data to create.</param>
        /// <returns>Returns the created critic.</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<ActionResult<ResponseCriticDTO>> CreateAsync(RequestCriticDTO requestCriticDTO)
        {
            var result = await _criticService.CreateAsync(requestCriticDTO);

            return Ok(result);
        }

        /// <summary>
        /// Get a critic by ID.
        /// </summary>
        /// <param name="id">The ID of the critic.</param>
        /// <returns>Returns the critic with the specified ID.</returns>
        [HttpGet("{id:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ResponseCriticDTO>> GetByIdAsync(Guid id)
        {
            var result = await _criticService.GetByIdAsync(id);

            return Ok(result);
        }

        /// <summary>
        /// Removes a critic by their ID.
        /// </summary>
        /// <param name="id">The ID of the critic to remove.</param>
        /// <returns>Returns the removed critic.</returns>
        [HttpDelete("{id:guid}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ResponseCriticDTO>> RemoveAsync(Guid id)
        {
            var result = await _criticService.RemoveCriticAsync(id);

            return Ok(result);
        }

        /// <summary>
        /// Updates an existing critic.
        /// </summary>
        /// <param name="id">The ID of the critic to update.</param>
        /// <param name="requestCriticDTO">The updated critic data.</param>
        /// <returns>Returns the updated critic.</returns>
        [HttpPut("{id:guid}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ResponseCriticDTO>> UpdateAsync(Guid id, RequestCriticDTO requestCriticDTO)
        {
            var result = await _criticService.UpdateAsync(id, requestCriticDTO);

            return Ok(result);
        }
    }
}
