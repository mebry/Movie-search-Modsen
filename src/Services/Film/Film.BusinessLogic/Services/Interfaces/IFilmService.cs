using Film.BusinessLogic.DTOs.RequestDTOs;
using Film.BusinessLogic.DTOs.ResponseDTOs;

namespace Film.BusinessLogic.Services.Interfaces
{
    /// <summary>
    /// Service interface for films.
    /// </summary>
    public interface IFilmService
    {
        /// <summary>
        /// Creates a new film.
        /// </summary>
        /// <param name="film">The film data.</param>
        /// <returns>A task representing the asynchronous operation. The result contains the created data.</returns>
        Task<FilmResponseDTO> CreateAsync(FilmRequestDTO film);

        /// <summary>
        /// Retrieves a film by its ID.
        /// </summary>
        /// <param name="id">The ID of the film.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task<FilmResponseDTO> GetByIdAsync(Guid id);

        /// <summary>
        /// Updates a film.
        /// </summary>
        /// <param name="id">The ID of the film.</param>
        /// <param name="film">The updated film data.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task UpdateAsync(Guid id, FilmRequestDTO film);

        /// <summary>
        /// Deletes a film.
        /// </summary>
        /// <param name="id">The ID of the film.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task DeleteAsync(Guid id);

        /// <summary>
        /// Retrieves a list of films based on pagination, filtering, and sorting criteria.
        /// </summary>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="filterQueryString">The filter query string.</param>
        /// <param name="orderByQueryString">The order by query string.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task<IEnumerable<FilmResponseDTO>> GetFilmsAsync(int pageNumber, int pageSize, string filterQueryString, string orderByQueryString);
    }
}
