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

        [HttpGet("{id}")]
        public async Task<ActionResult<ResponseRatingDTO>> GetById(Guid id)
        {
            var rating = await _ratingService.GetByIdAsync(id);

            return Ok(rating);
        }

        [HttpPost]
        public async Task<ActionResult<ResponseRatingDTO>> Create(RequestRatingDTO ratingDto)
        {
            var rating = await _ratingService.CreateAsync(ratingDto);

            return Ok(rating);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ResponseRatingDTO>> Update(Guid id, RequestRatingDTO ratingDto)
        {
            var rating = await _ratingService.UpdateAsync(id, ratingDto);

            return Ok(rating);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ResponseRatingDTO>> Delete(Guid id)
        {
            var rating = await _ratingService.DeleteAsync(id);

            return Ok(rating);
        }
    }
}
