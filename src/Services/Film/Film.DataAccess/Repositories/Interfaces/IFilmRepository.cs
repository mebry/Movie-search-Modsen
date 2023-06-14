using Film.DataAccess.Entities;

namespace Film.DataAccess.Repositories.Interfaces
{
    /// <summary>
    /// Repository interface for film entities, extending the generic IRepository interface.
    /// </summary>
    public interface IFilmRepository : IRepository<FilmModel>
    {
        /// <summary>
        /// Retrieves a collection of film models based on the specified pagination, filtering, and sorting parameters.
        /// </summary>
        /// <param name="pageNumber">The page number to retrieve.</param>
        /// <param name="pageSize">The number of films per page.</param>
        /// <param name="filterQueryString">The query string for filtering films.</param>
        /// <param name="orderByQueryString">The query string for ordering films.</param>
        /// <returns>A task representing the asynchronous operation that returns the collection of film models.</returns>
        Task<IEnumerable<FilmModel>> GetFilms(int pageNumber, int pageSize, string filterQueryString, string orderByQueryString);
    }
}
