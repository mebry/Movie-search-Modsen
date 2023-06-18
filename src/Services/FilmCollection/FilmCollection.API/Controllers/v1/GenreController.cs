using FilmCollection.API.Extensions;
using FilmCollection.BusinessLogic.DTOs.RequestDTOs;
using FilmCollection.BusinessLogic.Services.Interfaces;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace FilmCollection.API.Controllers.v1
{
    [Route("api/v1/genres")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "v1")]
    public class GenreController : ControllerBase
    {
        private readonly IGenreService _genreService;
        private readonly IValidator<GenreRequestDto> _validator;
        private readonly ILogger _logger;

        public GenreController(IGenreService genreService, IValidator<GenreRequestDto> validator, ILogger logger)
        {
            _genreService = genreService;
            _validator = validator;
            _logger = logger;
        }

        [HttpGet]
        [ProducesResponseType(200)]
        public async Task<IActionResult> GetAllGenresAsync()
        {
            var genresToReturn = await _genreService.GetAllGenresAsync();
            return Ok(genresToReturn);
        }

        [HttpGet("{genreId}", Name = "GetGenreById")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetGenreAsync(Guid genreId)
        {
            var genreToReturn = await _genreService.GetGenreAsync(genreId);
            return Ok(genreToReturn);
        }

        [HttpPut]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(409)]
        public async Task<IActionResult> CreateGenreAsync(GenreRequestDto genreRequest)
        {
            var result = await _validator.ValidateAsync(genreRequest);
            if (!result.IsValid)
            {
                result.AddToModelState(ModelState);
                _logger.LogError("Invalid data was provided when trying to create a genre");
                return BadRequest(modelState: ModelState);
            }
            var createdGenre = await _genreService.CreateGenreAsync(genreRequest);
            return CreatedAtRoute("GetGenreById", new { genreId = createdGenre.Id }, createdGenre);
        }

        [HttpDelete("genreId")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> DeleteGenreAsync(Guid genreId)
        {
            await _genreService.DeleteGenreAsync(genreId);
            return NoContent();
        }


        
    }
}
