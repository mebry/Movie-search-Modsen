using FilmCollection.BusinessLogic.DTOs.RequestDTOs;
using FilmCollection.BusinessLogic.DTOs.ResponseDTOs;
using FilmCollection.BusinessLogic.Services.Interfaces;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace FilmCollection.API.Controllers.v1
{
    public class FilmGenresController : BaseApiController
    {
        private readonly IFilmGenreService _filmGenreService;

        public FilmGenresController(IFilmGenreService filmGenreService, ILogger<BaseApiController> logger)
            : base(logger)
        {
            _filmGenreService = filmGenreService;
        }

        [HttpGet("{genreId}/{filmId}", Name = "GetFilmGenreById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetFilmGenreAsync(Guid genreId, Guid filmId)
        {
            var associationToReturn = await _filmGenreService.GetFilmGenreAsync(filmId, genreId);
            return Ok(associationToReturn);
        }
    }
}
