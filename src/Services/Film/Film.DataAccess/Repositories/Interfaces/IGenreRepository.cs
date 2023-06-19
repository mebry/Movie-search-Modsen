using Film.DataAccess.Entities;

namespace Film.DataAccess.Repositories.Interfaces
{
    /// <summary>
    /// Interface for a genre repository.
    /// </summary>
    public interface IGenreRepository : IRepository<Genre>
    {
        /// <summary>
        /// Retrieves all genres.
        /// </summary>
        /// <returns>A collection of genres.</returns>
        Task<IEnumerable<Genre>> GetGenresAsync();

        /// <summary>
        /// Retrieves a genre entity by its name asynchronously.
        /// </summary>
        /// <param name="name">The name of the genre to retrieve.</param>
        /// <returns>A task representing the asynchronous operation that returns the genre entity.</returns>
        Task<Genre> GetGenreByNameAsync(string name);
    }
}
