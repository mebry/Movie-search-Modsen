using Film.BusinessLogic.DTOs.RequestDTOs;
using Film.BusinessLogic.DTOs.ResponseDTOs;

namespace Film.BusinessLogic.Services.Interfaces
{
    /// <summary>
    /// Service interface for genres.
    /// </summary>
    public interface IGenreService
    {
        /// <summary>
        /// Creates a new genre.
        /// </summary>
        /// <param name="genre">The genre data.</param>
        /// <returns>A task representing the asynchronous operation. The result contains the created data.</returns>
        Task<GenreResponseDTO> CreateAsync(GenreRequestDTO genre);

        /// <summary>
        /// Retrieves a genre by its ID.
        /// </summary>
        /// <param name="id">The ID of the genre.</param>
        /// <returns>A task representing the asynchronous operation. The result contains the genre data.</returns>
        Task<GenreResponseDTO> GetByIdAsync(Guid id);

        /// <summary>
        /// Updates a genre.
        /// </summary>
        /// <param name="id">The ID of the genre.</param>
        /// <param name="genre">The updated genre data.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task UpdateAsync(Guid id, GenreRequestDTO genre);

        /// <summary>
        /// Deletes a genre.
        /// </summary>
        /// <param name="id">The ID of the genre to delete.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task DeleteAsync(Guid id);

        /// <summary>
        /// Retrieves genres by name.
        /// </summary>
        /// <param name="name">The name of the genres to retrieve.</param>
        /// <returns>A task representing the asynchronous operation. The result contains a  genre.</returns>
        Task<GenreResponseDTO> GetByNameAsync(string name);

        /// <summary>
        /// Retrieves all genres.
        /// </summary>
        /// <returns>A task representing the asynchronous operation that returns a collection of GenreResponseDTO objects.</returns>
        Task<IEnumerable<GenreResponseDTO>> GetAllAsync();
    }
}
