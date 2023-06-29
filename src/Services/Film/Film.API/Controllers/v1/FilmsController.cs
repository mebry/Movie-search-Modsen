using Film.BusinessLogic.DTOs.RequestDTOs;
using Film.BusinessLogic.Services.Interfaces;
using Film.DataAccess.Entities;
using Microsoft.AspNetCore.Mvc;
using Shared.Enums;
using System.Diagnostics.Metrics;
using System.Runtime.InteropServices;

namespace Film.API.Controllers.v1
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class FilmsController : ControllerBase
    {
        private readonly IFilmService _filmService;
        private readonly IFilmGenreService _filmGenreService;
        private readonly IFilmTagService _filmTagService;
        private readonly IFilmCountryService _filmCountryService;

        public FilmsController(IFilmService filmService, IFilmGenreService filmGenreService,
            IFilmTagService filmTagService, IFilmCountryService filmCountryService)
        {
            _filmService = filmService;
            _filmGenreService = filmGenreService;
            _filmTagService = filmTagService;
            _filmCountryService = filmCountryService;
        }

        /// <summary>
        /// Creates a new film.
        /// </summary>
        /// <param name="film">The film data.</param>
        /// <returns>The created film.</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<IActionResult> CreateAsync([FromBody] FilmRequestDTO film)
        {
            var createdFilm = await _filmService.CreateAsync(film);

            return CreatedAtRoute("GetFilmById", new { id = createdFilm.Id }, createdFilm);
        }

        /// <summary>
        /// Retrieves a paginated list of films.
        /// </summary>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="filterQueryString">The filter query string.</param>
        /// <param name="orderByQueryString">The order by query string.</param>
        /// <returns>The paginated list of films.</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAsync([FromQuery] string filterQueryString,
            [FromQuery] string orderByQueryString, int pageNumber = 1, int pageSize = 10)
        {
            var films = await _filmService.GetFilmsAsync(pageNumber, pageSize, filterQueryString, orderByQueryString);

            return Ok(films);
        }

        /// <summary>
        /// Retrieves a film by Id.
        /// </summary>
        /// <param name="id">The Id of the film.</param>
        /// <returns>The film with the specified Id.</returns>
        [HttpGet("{id}", Name = "GetFilmById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            var film = await _filmService.GetByIdAsync(id);

            return Ok(film);
        }

        /// <summary>
        /// Updates an existing film.
        /// </summary>
        /// <param name="id">The Id of the film.</param>
        /// <param name="film">The updated film data.</param>
        /// <returns>No content.</returns>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateAsync(Guid id, [FromBody] FilmRequestDTO film)
        {
            await _filmService.UpdateAsync(id, film);

            return NoContent();
        }

        /// <summary>
        /// Deletes a film.
        /// </summary>
        /// <param name="id">The Id of the film to delete.</param>
        /// <returns>No content.</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            await _filmService.DeleteAsync(id);

            return NoContent();
        }

        /// <summary>
        /// Adds a genre for a film.
        /// </summary>
        /// <param name="filmId">The Id of the film.</param>
        /// <param name="genreId">The Id of the genre.</param>
        /// <returns>No content.</returns>
        [HttpPost("{filmId}/genres/{genreId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> AddGenreForFilmAsync(Guid filmId, Guid genreId)
        {
            await _filmGenreService.CreateAsync(new FilmGenreRequestDTO { FilmId = filmId, GenreId = genreId });

            return NoContent();
        }

        /// <summary>
        /// Removes a genre from a film.
        /// </summary>
        /// <param name="filmId">The Id of the film.</param>
        /// <param name="genreId">The Id of the genre.</param>
        /// <returns>No content.</returns>
        [HttpDelete("{filmId}/genres/{genreId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> RemoveGenreForFilmAsync(Guid filmId, Guid genreId)
        {
            await _filmGenreService.DeleteAsync(filmId, genreId);

            return NoContent();
        }

        /// <summary>
        /// Adds a tag for a film.
        /// </summary>
        /// <param name="filmId">The Id of the film.</param>
        /// <param name="tagId">The Id of the tag.</param>
        /// <returns>No content.</returns>
        [HttpPost("{filmId}/tags/{tagId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> AddTagForFilmAsync(Guid filmId, Guid tagId)
        {
            await _filmTagService.CreateAsync(new FilmTagRequestDTO { FilmId = filmId, TagId = tagId });

            return NoContent();
        }

        /// <summary>
        /// Removes a tag from a film.
        /// </summary>
        /// <param name="filmId">The Id of the film.</param>
        /// <param name="tagId">The Id of the tag.</param>
        /// <returns>No content.</returns>
        [HttpDelete("{filmId}/tags/{tagId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> RemoveTagForFilmAsync(Guid filmId, Guid tagId)
        {
            await _filmTagService.DeleteAsync(filmId, tagId);

            return NoContent();
        }

        /// <summary>
        /// Adds a country for a film.
        /// </summary>
        /// <param name="filmId">The Id of the film.</param>
        /// <param name="countryId">The Id of the country.</param>
        /// <returns>No content.</returns>
        [HttpPost("{filmId}/countries/{countryId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> AddCountryForFilmAsync(Guid filmId, Countries countryId)
        {
            await _filmCountryService.CreateAsync(new FilmCountryRequestDTO { FilmId = filmId, CountryId = countryId });

            return NoContent();
        }

        /// <summary>
        /// Removes a country from a film.
        /// </summary>
        /// <param name="filmId">The Id of the film.</param>
        /// <param name="countryId">The Id of the country.</param>
        /// <returns>No content.</returns>
        [HttpDelete("{filmId}/countries/{countryId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> RemoveCountryForFilmAsync(Guid filmId, Countries countryId)
        {
            await _filmCountryService.DeleteAsync(filmId, countryId);

            return NoContent();
        }
    }
}
