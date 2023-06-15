using Film.DataAccess.Contexts;
using Film.DataAccess.Entities;
using Film.DataAccess.Repositories.Interfaces;

namespace Film.DataAccess.Repositories.Implementations
{
    /// <summary>
    /// Repository for managing film-tag relationships.
    /// </summary>
    public class FilmTagRepository : IFilmTagRepository
    {
        private readonly FilmContext _context;

        public FilmTagRepository(FilmContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Creates a new film-tag relationship.
        /// </summary>
        /// <param name="filmTag">The film-tag relationship to create.</param>
        public void Create(FilmTag filmTag)
        {
            _context.FilmTags.Add(filmTag);
        }

        /// <summary>
        /// Deletes a film-tag relationship.
        /// </summary>
        /// <param name="filmId">The ID of the film.</param>
        /// <param name="tagId">The ID of the tag.</param>
        public void Delete(Guid filmId, Guid tagId)
        {
            var filmTag = new FilmTag { FilmId = filmId, TagId = tagId };
            _context.FilmTags.Remove(filmTag);
        }

        /// <summary>
        /// Saves the changes made to the repository asynchronously.
        /// </summary>
        /// <returns>A task that represents the asynchronous save operation.</returns>
        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
