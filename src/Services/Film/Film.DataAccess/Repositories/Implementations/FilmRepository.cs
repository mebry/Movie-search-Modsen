using Film.DataAccess.Contexts;
using Film.DataAccess.Entities;
using Film.DataAccess.Extensions;
using Film.DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Film.DataAccess.Repositories.Implementations
{
    /// <summary>
    /// Repository class for managing films.
    /// </summary>
    public class FilmRepository : IFilmRepository
    {
        private readonly FilmContext _context;

        public FilmRepository(FilmContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Creates a new film entity.
        /// </summary>
        /// <param name="entity">The film entity to create.</param>
        public void Create(FilmModel entity)
        {
            _context.Films.Add(entity);
        }

        /// <summary>
        /// Deletes a film entity.
        /// </summary>
        /// <param name="id">The Id of the film.</param>
        public void Delete(Guid id)
        {
            var film = new FilmModel { Id = id };
            _context.Films.Remove(film);
        }

        /// <summary>
        /// Retrieves a film entity by its Id asynchronously.
        /// </summary>
        /// <param name="id">The Id of the film.</param>
        /// <returns>A task that represents the asynchronous retrieval operation.</returns>
        public async Task<FilmModel> GetByIdAsync(Guid id)
        {
            var film = await _context.Films.AsNoTracking()
                .IncludeRelatedData()
                .FirstOrDefaultAsync(x => x.Id == id);

            return film;
        }

        /// <summary>
        /// Retrieves a film entity by its title and release date asynchronously.
        /// </summary>
        /// <param name="title">The title of the film.</param>
        /// <param name="releaseDate">The release date of the film.</param>
        /// <returns>A task that represents the asynchronous retrieval operation.</returns>
        public async Task<FilmModel> GetByTitleAndReleaseDateAsync(string title, DateOnly releaseDate)
        {
            var film = await _context.Films.AsNoTracking()
                .IncludeRelatedData()
                .FirstOrDefaultAsync(x => x.Title == title && x.ReleaseDate == releaseDate);

            return film;
        }

        /// <summary>
        /// Retrieves a collection of film entities based on specified filtering, sorting, and pagination criteria asynchronously.
        /// </summary>
        /// <param name="pageNumber">The page number to retrieve.</param>
        /// <param name="pageSize">The number of films per page.</param>
        /// <param name="filterQueryString">The filter criteria in the form of query string.</param>
        /// <param name="orderByQueryString">The sorting criteria in the form of query string.</param>
        /// <returns>A task that represents the asynchronous retrieval operation.</returns>
        public async Task<IEnumerable<FilmModel>> GetFilmsAsync(int pageNumber, int pageSize, string filterQueryString,
            string orderByQueryString)
        {
            var films = await _context.Films.AsNoTracking()
                .IncludeRelatedData()
                .Filter(filterQueryString)
                .Sort(orderByQueryString)
                .Paginate(pageNumber, pageSize)
                .ToListAsync();

            return films;
        }

        /// <summary>
        /// Saves the changes made to the repository asynchronously.
        /// </summary>
        /// <returns>A task that represents the asynchronous save operation.</returns>
        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Updates an existing film entity.
        /// </summary>
        /// <param name="entity">The film entity to update.</param>
        public void Update(FilmModel entity)
        {
            _context.Films.Update(entity);
        }
    }
}
