using Microsoft.AspNetCore.Mvc;
using Rating.BusinessLogic.DTOs;
using Rating.BusinessLogic.Services.RatingServices;

namespace Rating.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RatingController : ControllerBase
    {
        private readonly IRatingService _ratingService;

        public RatingController(IRatingService ratingService)
        {
            _ratingService = ratingService;
        }

        /// <summary>
        /// Retrieves a rating by Id.
        /// </summary>
        /// <param name="id">The Id of the rating.</param>
        /// <response code="200">Return response rating.</response>
        /// <response code="404">If id is not found.</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ResponseRatingDTO>> GetById(Guid id)
        {
            var rating = await _ratingService.GetByIdAsync(id);

            return Ok(rating);
        }

        /// <summary>
        /// Create rating
        /// </summary>
        /// <response code="200">Return response rating.</response>
        /// <response code="409">If the user has already rated the film with filmId.</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<ActionResult<ResponseRatingDTO>> Create(RequestRatingDTO ratingDto)
        {
            var rating = await _ratingService.CreateAsync(ratingDto);

            return Ok(rating);
        }

        /// <summary>
        /// Update rating.
        /// </summary>
        /// <param name="id">The Id of the rating.</param>
        /// <response code="200">Return response rating.</response>
        /// <response code="404">If id is not found.</response>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ResponseRatingDTO>> Update(Guid id, RequestRatingDTO ratingDto)
        {
            var rating = await _ratingService.UpdateAsync(id, ratingDto);

            return Ok(rating);
        }

        /// <summary>
        /// Delete rating.
        /// </summary>
        /// <param name="id">The Id of the rating.</param>
        /// <response code="200">Return response rating.</response>
        /// <response code="404">If id is not found.</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ResponseRatingDTO>> Delete(Guid id)
        {
            var rating = await _ratingService.DeleteAsync(id);

            return Ok(rating);
        }
    }
}
