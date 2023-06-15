using Film.BusinessLogic.DTOs.RequestDTOs;
using Film.BusinessLogic.DTOs.ResponseDTOs;

namespace Film.BusinessLogic.Services.Interfaces
{
    /// <summary>
    /// Service interface for film genres.
    /// </summary>
    public interface IFilmGenreService
    {
        /// <summary>
        /// Creates a new film genre.
        /// </summary>
        /// <param name="filmGenre">The film genre data.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task CreateAsync(FilmGenreRequestDTO filmGenre);

        /// <summary>
        /// Deletes a film genre.
        /// </summary>
        /// <param name="filmId">The ID of the film.</param>
        /// <param name="genreId">The ID of the genre.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task DeleteAsync(Guid filmId, Guid genreId);
    }
}
