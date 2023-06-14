using Film.DataAccess.Entities;

namespace Film.DataAccess.Repositories.Interfaces
{
    /// <summary>
    /// Interface for a film tag repository.
    /// </summary>
    public interface IFilmTagRepository
    {
        /// <summary>
        /// Creates a new film tag.
        /// </summary>
        /// <param name="filmTag">The film tag to create.</param>
        /// <returns>The created film tag.</returns>
        FilmTag Create(FilmTag filmTag);

        /// <summary>
        /// Deletes a film tag by film ID and tag ID.
        /// </summary>
        /// <param name="filmId">The ID of the film.</param>
        /// <param name="tagId">The ID of the tag.</param>
        void Delete(Guid filmId, Guid tagId);

        /// <summary>
        /// Saves changes asynchronously.
        /// </summary>
        /// <returns>A task that represents the asynchronous save operation.</returns>
        Task SaveChangesAsync();
    }
}
