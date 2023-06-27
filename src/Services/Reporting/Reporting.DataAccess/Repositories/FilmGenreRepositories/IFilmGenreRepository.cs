using Reporting.DataAccess.Entities;

namespace Reporting.DataAccess.Repositories.FilmGenreRepositories
{
    public interface IFilmGenreRepository
    {
        public void Create(FilmGenre filmGenre);
        public void Delete(Guid filmId, Guid genreId);

        /// <summary>
        /// Saves changes asynchronously.
        /// </summary>
        /// <returns>A task that represents the asynchronous save operation.</returns>
        public Task SaveChangesAsync();
    }
}
