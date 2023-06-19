using Microsoft.AspNetCore.Mvc;
using Reviews.BusinessLogic.DTOs;
using Reviews.BusinessLogic.Services.Interfaces;

namespace Reviews.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TypeOfReviewController : ControllerBase
    {
        private readonly ITypeOfReviewService _typeOfReviewService;

        public TypeOfReviewController(ITypeOfReviewService typeOfReviewService)
        {
            _typeOfReviewService = typeOfReviewService;
        }

        /// <summary>
        ///  Creates a new type of review.
        /// </summary>
        /// <param name="requestTypeOfReviewDTO">The type of review data to create.</param>
        /// <returns>Returns the created type of review.</returns>
        [HttpPost]
        public async Task<ActionResult<ResponseTypeOfReviewDTO>> CreateAsync(RequestTypeOfReviewDTO requestTypeOfReviewDTO)
        {
            var result = await _typeOfReviewService.CreateAsync(requestTypeOfReviewDTO);

            return Ok(result);
        }
    }
}
