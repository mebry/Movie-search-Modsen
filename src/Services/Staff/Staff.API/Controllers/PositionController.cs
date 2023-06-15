using Microsoft.AspNetCore.Mvc;
using Staff.BusinessLogic.DTOs;
using Staff.BusinessLogic.Services.Interfaces;

namespace Staff.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PositionController : ControllerBase
    {
        private readonly IPositionService _positionService;

        public PositionController(IPositionService positionService)
        {
            _positionService = positionService;
        }

        /// <summary>
        /// Get all positions
        /// </summary>
        /// <returns>Returns positions</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ResponsePositionDTO>>> GetAsync()
        {
            var result = await _positionService.GetPositionsAsync();

            return Ok(result);
        }

        /// <summary>
        /// Get position by ID
        /// </summary>
        /// <param name="id">The ID of the position</param>
        /// <returns>Returns the position with the specified ID</returns>
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<ResponsePositionDTO>> GetByIdAsync(Guid id)
        {
            var result = await _positionService.GetPositionByIdAsync(id);

            return Ok(result);
        }

        /// <summary>
        /// Create a new position
        /// </summary>
        /// <param name="requestPositionDTO">The position data to create</param>
        /// <returns>Returns the created position</returns>
        [HttpPost]
        public async Task<ActionResult<ResponsePositionDTO>> CreateAsync(RequestPositionDTO requestPositionDTO)
        {
            var result = await _positionService.CreateAsync(requestPositionDTO);

            return Ok(result);
        }
    }
}
