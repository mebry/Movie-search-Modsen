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

        [HttpPost]
        public async Task<ActionResult<FilmDTO>> Create(FilmDTO filmDto)
        {
            var film = await _filmService.Create(filmDto);

            return Ok(film);
        }

        [HttpPut]
        public async Task<ActionResult<FilmDTO>> Update(FilmDTO filmDto)
        {
            var film = await _filmService.Update(filmDto);

            return Ok(film);
        }

        [HttpDelete]
        public async Task<ActionResult<FilmDTO>> Delete(Guid id)
        {
            var filmDto = new FilmDTO
            {
                Id = id
            };
            var film = await _filmService.Delete(filmDto);

            return Ok(film);
        }
    }
}
