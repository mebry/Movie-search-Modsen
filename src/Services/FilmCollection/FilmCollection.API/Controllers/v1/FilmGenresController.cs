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
        private readonly IValidator<FilmGenreRequestDto> _validator;

        public FilmGenresController(IFilmGenreService filmGenreService, IValidator<FilmGenreRequestDto> validator, ILogger<BaseApiController> logger)
            : base(logger)
        {
            _filmGenreService = filmGenreService;
            _validator = validator;
        }

        [HttpGet("{genreId}/{filmId}", Name = "GetFilmGenreById")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetFilmGenreAsync(Guid genreId, Guid filmId)
        {
            var associationToReturn = await _filmGenreService.GetFilmGenreAsync(filmId, genreId);
            return Ok(associationToReturn);
        }

        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(409)]
        public async Task<IActionResult> CreateFilmGenreAsync(FilmGenreRequestDto filmGenreRequest)
        {
            var result = await _validator.ValidateAsync(filmGenreRequest);
            if (!result.IsValid)
                ProcessInvalidValidationResult(result, "Invalid data was provided when trying to create a FilmGenre association");
            var createdFilmGenre = await _filmGenreService.CreateFilmGenreAsync(filmGenreRequest);
            return CreatedAtRoute("GetFilmGenreById", new { genreId = createdFilmGenre.GenreId, filmId = createdFilmGenre.BaseFilmInfoId }, createdFilmGenre);
        }

        [HttpDelete("{genreId}/{filmId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> DeleteFilmGenreAsync(Guid genreId, Guid filmId)
        {
            await _filmGenreService.DeleteFilmGenreAsync(filmId, genreId);
            return NoContent();
        }
        

    }
}
