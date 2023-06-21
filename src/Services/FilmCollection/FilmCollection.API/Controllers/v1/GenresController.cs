using FilmCollection.API.Extensions;
using FilmCollection.BusinessLogic.DTOs.RequestDTOs;
using FilmCollection.BusinessLogic.Services.Interfaces;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace FilmCollection.API.Controllers.v1
{
    public class GenresController : BaseApiController
    {
        private readonly IGenreService _genreService;
        private readonly ILogger _logger;

        public GenresController(IGenreService genreService, ILogger<BaseApiController> logger)
            : base(logger)
        {
            _genreService = genreService;
            _logger = logger;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllGenresAsync()
        {
            var genresToReturn = await _genreService.GetAllGenresAsync();
            return Ok(genresToReturn);
        }

        [HttpGet("{genreId}", Name = "GetGenreById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetGenreAsync(Guid genreId)
        {
            var genreToReturn = await _genreService.GetGenreAsync(genreId);
            return Ok(genreToReturn);
        }
    }
}
