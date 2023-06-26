using Reporting.DataAccess.Entities;
using Reporting.DataAccess.Interfaces;

namespace Reporting.DataAccess.Repositories.FilmGenreRepositories
{
    public interface IFilmGenreRepository : ISaveChangesAsync
    {
        public void Create(FilmGenre filmGenre);
        public void Delete(Guid filmId, Guid genreId);
    }
}
