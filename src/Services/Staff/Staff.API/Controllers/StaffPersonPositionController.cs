using Microsoft.AspNetCore.Mvc;
using Staff.BusinessLogic.DTOs;
using Staff.BusinessLogic.Services.Interfaces;

namespace Staff.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StaffPersonPositionController : Controller
    {
        private readonly IStaffPersonPositionService _staffPersonPositionService;

        public StaffPersonPositionController(IStaffPersonPositionService staffPersonPositionService)
        {
            _staffPersonPositionService = staffPersonPositionService;
        }

        /// <summary>
        /// Get films by staff person ID and position ID
        /// </summary>
        /// <param name="staffPersonId">The ID of the staff person</param>
        /// <param name="positionId">The ID of the position</param>
        /// <returns>Returns films associated with the staff person and position</returns>
        [HttpGet("films/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<ResponseFilmDTO>>> GetFilmsByStaffPersonAndPositionAsync(Guid staffPersonId, Guid positionId)
        {
            var result = await _staffPersonPositionService.GetFilmsByStaffPersonAndPositionAsync(staffPersonId, positionId);

            return Ok(result);
        }

        /// <summary>
        /// Get positions by staff person ID
        /// </summary>
        /// <param name="staffPersonId">The ID of the staff person</param>
        /// <returns>Returns positions associated with the staff person</returns>
        [HttpGet("position/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<ResponsePositionDTO>>> GetPositionsByStaffPersonIdAsync(Guid staffPersonId)
        {
            var result = await _staffPersonPositionService.GetPositionsByStaffPersonIdAsync(staffPersonId);

            return Ok(result);
        }

        /// <summary>
        /// Create a new staff person position
        /// </summary>
        /// <param name="staffPersonId">The ID of the staff person</param>
        /// <param name="positionId">The ID of the position</param>
        /// <param name="filmId">The ID of the film</param>
        /// <returns>Returns the created staff person position</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<ActionResult<StaffPersonPositionDTO>> CreateAsync(Guid staffPersonId, Guid positionId, Guid filmId)
        {
            var result = await _staffPersonPositionService.CreateAsync(staffPersonId, positionId, filmId);

            return Ok(result);
        }
    }
}
