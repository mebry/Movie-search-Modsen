using Microsoft.AspNetCore.Mvc;
using Reviews.BusinessLogic.DTOs;
using Reviews.BusinessLogic.Services.Interfaces;

namespace Reviews.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReviewController : ControllerBase
    {
        private readonly IReviewService _reviewService;

        public ReviewController(IReviewService reviewService)
        {
            _reviewService = reviewService;
        }

        /// <summary>
        /// Creates a new review.
        /// </summary>
        /// <param name="requestReviewDTO">The review data to create.</param>
        /// <returns>Returns the created review.</returns>
        [HttpPost]
        public async Task<ActionResult<ResponseReviewDTO>> CreateAsync(RequestReviewDTO requestReviewDTO)
        {
            var result = await _reviewService.CreateAsync(requestReviewDTO);

            return Ok(result);
        }

        /// <summary>
        /// Gets all reviews by a critic's ID. 
        /// </summary>
        /// <param name="id">The ID of the critic.</param>
        /// <returns>Returns reviews by the critic's ID.</returns>
        [HttpGet("critic/{id:guid}")]
        public async Task<ActionResult<IEnumerable<ResponseReviewDTO>>> GetAllByCriticIdAsync(Guid id)
        {
            var result = await _reviewService.GetAllByCriticIdAsync(id);

            return Ok(result);
        }

        /// <summary>
        /// Gets all reviews for a film based on the film ID and review type.
        /// </summary>
        /// <param name="filmId">The ID of the film.</param>
        /// <param name="typeOfReviewId">The ID of the review type.</param>
        /// <returns>Returns reviews for the film and review type.</returns>
        [HttpGet("{filmId:guid}/{typeOfReviewId:guid}")]
        public async Task<ActionResult<IEnumerable<ResponseReviewDTO>>> GetAllByFilmIdAndTypeAsync(Guid filmId, Guid typeOfReviewId)
        {
            var result = await _reviewService.GetAllByFilmIdAndTypeAsync(filmId, typeOfReviewId);

            return Ok(result);
        }

        [HttpGet("film/{filmId:guid}")]
        public async Task<ActionResult<IEnumerable<ResponseReviewDTO>>> GetAllByFilmIdAsync(Guid filmId)
        {
            var result = await _reviewService.GetAllByFilmIdAsync(filmId);

            return Ok(result);
        }

        /// <summary>
        /// Removes a review by their ID.
        /// </summary>
        /// <param name="id">The ID of the review to remove.</param>
        /// <returns>Returns the removed review.</returns>
        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<ResponseReviewDTO>> RemoveAsync(Guid id)
        {
            var result = await _reviewService.RemoveReviewAsync(id);

            return Ok(result);
        }

        /// <summary>
        /// Updates an existing review.
        /// </summary>
        /// <param name="id">The ID of the review to update.</param>
        /// <param name="requestReviewDTO">The updated review data.</param>
        /// <returns>Returns the updated review.</returns>
        [HttpPut("{id:guid}")]
        public async Task<ActionResult<ResponseReviewDTO>> UpdateAsync(Guid id, RequestReviewDTO requestReviewDTO)
        {
            var result = await _reviewService.UpdateAsync(id, requestReviewDTO);

            return Ok(result);
        }
    }
}
