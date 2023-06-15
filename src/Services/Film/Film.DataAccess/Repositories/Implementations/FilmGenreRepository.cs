using Film.DataAccess.Contexts;
using Film.DataAccess.Entities;
using Film.DataAccess.Repositories.Interfaces;

namespace Film.DataAccess.Repositories.Implementations
{
    /// <summary>
    /// Repository for managing film-genre relationships.
    /// </summary>
    public class FilmGenreRepository : IFilmGenreRepository
    {
        private readonly FilmContext _context;

        public FilmGenreRepository(FilmContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Creates a new film-genre relationship.
        /// </summary>
        /// <param name="filmGenre">The film-genre relationship to create.</param>
        public void Create(FilmGenre filmGenre)
        {
            _context.FilmGenres.Add(filmGenre);
        }

        /// <summary>
        /// Deletes a film-genre relationship.
        /// </summary>
        /// <param name="filmId">The ID of the film.</param>
        /// <param name="genreId">The ID of the genre.</param>
        public void Delete(Guid filmId, Guid genreId)
        {
            var filmGenre = new FilmGenre { FilmId = filmId, GenreId = genreId };
            _context.FilmGenres.Remove(filmGenre);
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
