using Staff.DataAccess.Entities;

namespace Staff.DataAccess.Repositories.Interfaces
{
    public interface IFilmRepository
    {
        public void RemoveFilm(Film film);
        public Task CreateAsync(Film film);
        public void Update(Film film);
        public Task<Film> GetFilmByIdAsync(Guid id);
    }
}
