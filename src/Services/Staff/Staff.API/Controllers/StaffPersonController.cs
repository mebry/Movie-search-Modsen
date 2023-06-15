using Microsoft.AspNetCore.Mvc;
using Staff.BusinessLogic.DTOs;
using Staff.BusinessLogic.Services.Interfaces;

namespace Staff.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StaffPersonController : ControllerBase
    {
        private readonly IStaffPersonService _staffPersonService;

        public StaffPersonController(IStaffPersonService staffPersonService)
        {
            _staffPersonService = staffPersonService;
        }

        /// <summary>
        ///  Get all staff persons
        /// </summary>
        /// <returns>Returns staff persons</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ResponseStaffPersonDTO>>> GetAsync()
        {
            var result = await _staffPersonService.GetStaffAsync();

            return Ok(result);
        }

        /// <summary>
        /// Get a staff person by ID
        /// </summary>
        /// <param name="id">The ID of the staff person</param>
        /// <returns>Returns the staff person with the specified ID</returns>
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<ResponseStaffPersonDTO>> GetByIdAsync(Guid id)
        {
            var result = await _staffPersonService.GetStaffPersonByIdAsync(id);

            return Ok(result);
        }

        /// <summary>
        /// Create a new staff person
        /// </summary>
        /// <param name="requestStaffPersonDTO">The staff person data to create</param>
        /// <returns>Returns the created staff person</returns>
        [HttpPost]
        public async Task<ActionResult<ResponseStaffPersonDTO>> CreateAsync(RequestStaffPersonDTO requestStaffPersonDTO)
        {
            var result = await _staffPersonService.CreateAsync(requestStaffPersonDTO);

            return Ok(result);
        }

        /// <summary>
        /// Update an existing staff person
        /// </summary>
        /// <param name="id">The ID of the staff person to update</param>
        /// <param name="requestStaffPersonDTO">The updated staff person data</param>
        /// <returns>Returns the updated staff person</returns>
        [HttpPut("{id:guid}")]
        public async Task<ActionResult<ResponseStaffPersonDTO>> UpdateAsync(Guid id, RequestStaffPersonDTO requestStaffPersonDTO)
        {
            var result = await _staffPersonService.UpdateAsync(id, requestStaffPersonDTO);

            return Ok(result);
        }
    }
}
