using Microsoft.AspNetCore.Mvc;
using Reporting.BusinessLogic.DTOs.ResponseDTOs;
using Reporting.BusinessLogic.Services.StaffPersonServices;

namespace Reporting.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffPersonController : ControllerBase
    {
        private readonly IStaffPersonReportingService _staffPersonReportingService;

        public StaffPersonController(IStaffPersonReportingService staffPersonReportingService)
        {
            _staffPersonReportingService = staffPersonReportingService;
        }

        [HttpGet("id")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ResponseStaffPersonPositionsInFilms>> GetStaffPersonPositionsInFIlms(Guid id)
        {
            var response = await _staffPersonReportingService.GetAllPositionsInFIlms(id);

            return Ok(response);
        }
    }
}
