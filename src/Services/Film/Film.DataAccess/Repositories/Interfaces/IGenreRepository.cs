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
        Task<IEnumerable<Genre>> GetGenres();
    }
}
