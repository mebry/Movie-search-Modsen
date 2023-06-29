using Film.BusinessLogic.DTOs.RequestDTOs;
using Film.BusinessLogic.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Film.API.Controllers.v1
{
    [Route("api/v{apiVersion:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    [ApiController]
    public class AgeRestrictionsController : ControllerBase
    {
        private readonly IAgeRestrictionService _ageRestrictionService;

        public AgeRestrictionsController(IAgeRestrictionService ageRestrictionService)
        {
            _ageRestrictionService = ageRestrictionService;
        }

        /// <summary>
        /// Creates a new age restriction.
        /// </summary>
        /// <param name="ageRestriction">The age restriction data.</param>
        /// <returns>The created age restriction.</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<IActionResult> CreateAsync([FromBody] AgeRestrictionRequestDTO ageRestriction)
        {
            var createdAgeRestriction = await _ageRestrictionService.CreateAsync(ageRestriction);

            return CreatedAtRoute("GetAgeRestrictionById", new { id = createdAgeRestriction.Id }, createdAgeRestriction);
        }

        /// <summary>
        /// Retrieves all age restrictions.
        /// </summary>
        /// <returns>The list of age restrictions.</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAsync()
        {
            var ageRestrictions = await _ageRestrictionService.GetAgeRestrictionsAsync();

            return Ok(ageRestrictions);
        }

        /// <summary>
        /// Retrieves an age restriction by Id.
        /// </summary>
        /// <param name="id">The Id of the age restriction.</param>
        /// <returns>The age restriction with the specified Id.</returns>
        [HttpGet("{id}", Name = "GetAgeRestrictionById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            var ageRestriction = await _ageRestrictionService.GetByIdAsync(id);

            return Ok(ageRestriction);
        }

        /// <summary>
        /// Updates an existing age restriction.
        /// </summary>
        /// <param name="id">The Id of the age restriction.</param>
        /// <param name="ageRestriction">The updated age restriction data.</param>
        /// <returns>No content.</returns>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateAsync(Guid id, [FromBody] AgeRestrictionRequestDTO ageRestriction)
        {
            await _ageRestrictionService.UpdateAsync(id, ageRestriction);

            return NoContent();
        }

        /// <summary>
        /// Deletes an age restriction.
        /// </summary>
        /// <param name="id">The Id of the age restriction to delete.</param>
        /// <returns>No content.</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            await _ageRestrictionService.DeleteAsync(id);

            return NoContent();
        }
    }
}
