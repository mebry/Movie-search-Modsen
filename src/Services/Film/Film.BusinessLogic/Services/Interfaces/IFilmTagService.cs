using Film.BusinessLogic.DTOs.RequestDTOs;
using System.Reflection.Metadata;

namespace Film.BusinessLogic.Services.Interfaces
{
    /// <summary>
    /// Service interface for film tags.
    /// </summary>
    public interface IFilmTagService
    {
        /// <summary>
        /// Creates a new film tag.
        /// </summary>
        /// <param name="filmTag">The film tag data.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task CreateAsync(FilmTagRequestDTO filmTag);

        /// <summary>
        /// Deletes a film tag.
        /// </summary>
        /// <param name="filmId">The ID of the film.</param>
        /// <param name="tagId">The ID of the tag.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task DeleteAsync(Guid filmId, Guid tagId);
    }
}
