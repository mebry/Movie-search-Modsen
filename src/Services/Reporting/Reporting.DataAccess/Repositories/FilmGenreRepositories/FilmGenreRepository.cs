using Reporting.DataAccess.Contexts;
using Reporting.DataAccess.Entities;

namespace Reporting.DataAccess.Repositories.FilmGenreRepositories
{
    internal class FilmGenreRepository : IFilmGenreRepository
    {
        private readonly ReportingContext _context;

        public FilmGenreRepository(ReportingContext context)
        {
            _context = context;
        }

        public void Create(FilmGenre filmGenre)
            => _context.FilmGenres.Add(filmGenre);

        public void Delete(Guid filmId, Guid genreId)
        {
            var filmGenre = new FilmGenre
            {
                FilmId = filmId,
                GenreId = genreId
            };

            _context.FilmGenres.Remove(filmGenre);
        }

        public async Task SaveChangesAsync()
            => await _context.SaveChangesAsync();
    }
}
