using Microsoft.AspNetCore.Mvc;
using Rating.BusinessLogic.DTOs;
using Rating.BusinessLogic.Services.FilmServices;

namespace Rating.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmController : ControllerBase
    {
        private readonly IFilmService _filmService;

        public FilmController(IFilmService filmService)
        {
            _filmService = filmService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<FilmDTO>> GetById(Guid id)
        {
            var film = await _filmService.GetByIdAsync(id);

            return Ok(film);
        }

        [HttpPost("{id}")]
        public async Task<ActionResult<FilmDTO>> Create(Guid id)
        {
            var filmDto = new FilmDTO
            {
                Id = id
            };
            var film = await _filmService.CreateAsync(filmDto);

            return Ok(film);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<FilmDTO>> Delete(Guid id)
        {
            var filmDto = new FilmDTO
            {
                Id = id
            };
            var film = await _filmService.DeleteAsync(filmDto);

            return Ok(film);
        }
    }
}
