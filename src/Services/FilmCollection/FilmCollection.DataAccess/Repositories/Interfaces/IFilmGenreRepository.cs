using FilmCollection.DataAccess.Models;

namespace FilmCollection.DataAccess.Repositories.Interfaces
{
    public interface IFilmGenreRepository
    {
        Task CreateFilmGenreAsync(FilmGenre filmGenre);

        Task DeleteFilmGenreAsync(FilmGenre filmGenre);
        Task<FilmGenre> GetFilmGenreAsync(Guid baseFilmInfoId, Guid genreId, bool trackChanges);
    }
}
