using Microsoft.EntityFrameworkCore;
using Staff.DataAccess.Contexts;
using Staff.DataAccess.Entities;
using Staff.DataAccess.Repositories.Interfaces;

namespace Staff.DataAccess.Repositories.Implementations
{
    public class FilmRepository : IFilmRepository
    {
        private readonly StaffsDbContext _dbContext;

        public FilmRepository(StaffsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CreateAsync(Film film)
        {
            await _dbContext.Films.AddAsync(film);
        }

        public async Task<Film> GetFilmByIdAsync(Guid id)
        {
            return await _dbContext.Films.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }

        public void RemoveFilm(Film film)
        {
            _dbContext.Films.Remove(film);
        }

        public void Update(Film film)
        {
            _dbContext.Films.Update(film);
        }
    }
}
