using Microsoft.EntityFrameworkCore;
using Rating.DataAccess.Contexts;
using Rating.DataAccess.Entities;

namespace Rating.DataAccess.Repositories.FilmRepositories
{
    internal class FilmRepository : IFilmRepository
    {
        private ApplicationContext _context;

        public FilmRepository(ApplicationContext context)
        {
            _context = context;
        }

        public void Create(Film entity)
            => _context.Add(entity);

        public void Delete(Film entity)
            => _context.Remove(entity);

        public IEnumerable<Film> GetAll()
            => _context.Films
                .AsNoTracking();

        public async Task<Film?> GetByIdAsync(Guid entityId)
             => await _context.Films
            .AsNoTracking()
            .FirstOrDefaultAsync(a => a.Id == entityId);

        public async Task SaveAsync()
             => await _context.SaveChangesAsync();

        public void Update(Film entity)
             => _context.Update(entity);
    }
}
