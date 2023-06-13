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
        public async Task<ActionResult<RatingDTO>> GetById(Guid id)
        {
            var rating = await _ratingService.GetByIdAsync(id);

            return Ok(rating);
        }

        [HttpPost]
        public async Task<ActionResult<RatingDTO>> Create(RatingDTO ratingDto)
        {
            var rating = await _ratingService.Create(ratingDto);

            return Ok(rating);
        }

        [HttpPut]
        public async Task<ActionResult<RatingDTO>> Update(RatingDTO ratingDto)
        {
            var rating = await _ratingService.Update(ratingDto);

            return Ok(rating);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<RatingDTO>> Delete(Guid id)
        {
            var ratingDto = new RatingDTO
            {
                Id = id
            };
            var rating = await _ratingService.Delete(ratingDto);

            return Ok(rating);
        }
    }
}
