using Film.BusinessLogic.DTOs.RequestDTOs;
using Film.BusinessLogic.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Film.API.Controllers.v1
{
    [Route("api/v{apiVersion:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    [ApiController]
    public class GenresController : ControllerBase
    {
        private readonly IGenreService _genreService;

        public GenresController(IGenreService genreService)
        {
            _genreService = genreService;
        }

        /// <summary>
        /// Creates a new genre.
        /// </summary>
        /// <param name="genre">The genre data.</param>
        /// <returns>The created genre.</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<IActionResult> CreateAsync([FromBody] GenreRequestDTO genre)
        {
            var createdGenre = await _genreService.CreateAsync(genre);

            return CreatedAtRoute("GetGenreById", new { id = createdGenre.Id }, createdGenre);
        }

        /// <summary>
        /// Retrieves all genres.
        /// </summary>
        /// <returns>The list of genres.</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAsync()
        {
            var genres = await _genreService.GetAllAsync();

            return Ok(genres);
        }

        /// <summary>
        /// Retrieves a genre by Id.
        /// </summary>
        /// <param name="id">The Id of the genre.</param>
        /// <returns>The genre with the specified Id.</returns>
        [HttpGet("{id}", Name = "GetGenreById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            var genre = await _genreService.GetByIdAsync(id);

            return Ok(genre);
        }

        /// <summary>
        /// Updates an existing genre.
        /// </summary>
        /// <param name="id">The Id of the genre.</param>
        /// <param name="genre">The updated genre data.</param>
        /// <returns>No content.</returns>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateAsync(Guid id, [FromBody] GenreRequestDTO genre)
        {
            await _genreService.UpdateAsync(id, genre);

            return NoContent();
        }

        /// <summary>
        /// Deletes a genre.
        /// </summary>
        /// <param name="id">The Id of the genre to delete.</param>
        /// <returns>No content.</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            await _genreService.DeleteAsync(id);

            return NoContent();
        }
    }
}
