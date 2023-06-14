using Film.DataAccess.Entities;

namespace Film.DataAccess.Repositories.Interfaces
{
    /// <summary>
    /// Interface for a film genre repository.
    /// </summary>
    public interface IFilmGenreRepository
    {
        /// <summary>
        /// Creates a new film genre.
        /// </summary>
        /// <param name="filmGenre">The film genre to create.</param>
        /// <returns>The created film genre.</returns>
        FilmGenre Create(FilmGenre filmGenre);

        /// <summary>
        /// Deletes a film genre by film ID and genre ID.
        /// </summary>
        /// <param name="filmId">The ID of the film.</param>
        /// <param name="genreId">The ID of the genre.</param>
        void Delete(Guid filmId, Guid genreId);

        /// <summary>
        /// Saves changes asynchronously.
        /// </summary>
        /// <returns>A task that represents the asynchronous save operation.</returns>
        Task SaveChangesAsync();
    }
}