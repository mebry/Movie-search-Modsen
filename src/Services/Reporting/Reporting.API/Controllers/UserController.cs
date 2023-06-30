using Microsoft.AspNetCore.Mvc;
using Reporting.BusinessLogic.DTOs.ResponseDTOs;
using Reporting.BusinessLogic.Services.RatingServices;
using Reporting.BusinessLogic.Services.UserServices;

namespace Reporting.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserReportingService _userReportingService;
        private readonly IRatingReportingService _ratingReportingService;

        public UserController(IUserReportingService userReportingService, IRatingReportingService ratingReportingService)
        {
            _userReportingService = userReportingService;
            _ratingReportingService = ratingReportingService;
        }

        [HttpGet("rating/{id}")]
        public async Task<ActionResult<List<ResponseGroupNumberOfFilmsByRating>>> GetDistributionsByEstimates(Guid id)
        {
            var response = await _ratingReportingService.GetResponseGroupNumberOfFilmsByRating(id);

            return Ok(response);
        }
    }
}
