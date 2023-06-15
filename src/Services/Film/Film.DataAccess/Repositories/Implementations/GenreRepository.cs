using Film.DataAccess.Contexts;
using Film.DataAccess.Entities;
using Film.DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Film.DataAccess.Repositories.Implementations
{
    /// <summary>
    /// Repository class for managing genres.
    /// </summary>
    public class GenreRepository : IGenreRepository
    {
        private readonly FilmContext _context;

        public GenreRepository(FilmContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Creates a new genre entity.
        /// </summary>
        /// <param name="entity">The genre entity to create.</param>
        public void Create(Genre entity)
        {
            _context.Genres.Add(entity);
        }

        /// <summary>
        /// Deletes a genre entity by Id.
        /// </summary>
        /// <param name="id">The Id of the genre entity to delete.</param>
        public void Delete(Guid id)
        {
            _context.Genres.Remove(new Genre { Id = id });
        }

        /// <summary>
        /// Retrieves a genre entity by Id asynchronously.
        /// </summary>
        /// <param name="id">The Id of the genre entity to retrieve.</param>
        /// <returns>The task result contains the genre entity if found; otherwise, null.</returns>
        public async Task<Genre> GetByIdAsync(Guid id)
        {
            var genre = await _context.Genres.AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);

            return genre;
        }

        /// <summary>
        /// Retrieves a genre entity by name asynchronously.
        /// </summary>
        /// <param name="name">The name of the genre entity to retrieve.</param>
        /// <returns>The task result contains the genre entity if found; otherwise, null.</returns>
        public async Task<Genre> GetGenreByNameAsync(string name)
        {
            var genre = await _context.Genres.AsNoTracking()
                .FirstOrDefaultAsync(x => x.Name == name);

            return genre;
        }

        /// <summary>
        /// Retrieves all genre entities asynchronously.
        /// </summary>
        /// <returns>The task result contains the list of genre entities.</returns>
        public async Task<IEnumerable<Genre>> GetGenresAsync()
        {
            var genres = await _context.Genres.AsNoTracking()
                .ToListAsync();

            return genres;
        }

        /// <summary>
        /// Saves the changes made to the context asynchronously.
        /// </summary>
        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Updates an existing genre entity.
        /// </summary>
        /// <param name="entity">The genre entity to update.</param>
        public void Update(Genre entity)
        {
            _context.Genres.Update(entity);
        }
    }
}
