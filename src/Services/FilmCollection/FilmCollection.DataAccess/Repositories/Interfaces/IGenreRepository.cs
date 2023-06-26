using FilmCollection.DataAccess.Models;

namespace FilmCollection.DataAccess.Repositories.Interfaces
{
    public interface IGenreRepository
    {
        Task CreateGenreAsync(Genre genre);
        Task DeleteGenreAsync(Genre genre);
        Task<Genre> GetGenreByIdAsync(Guid id, bool trackChanges);
        Task<IEnumerable<Genre>> GetAllGenresAsync(bool trackChanges);
        Task<Genre> GetGenreByNameAsync(string name, bool trackChanges);
        Task UpdateGenreAsync(Genre genre);
    }
}
