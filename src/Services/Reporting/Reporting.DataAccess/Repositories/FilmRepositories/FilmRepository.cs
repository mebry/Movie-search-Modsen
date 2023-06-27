using Microsoft.EntityFrameworkCore;
using Reporting.DataAccess.Contexts;
using Reporting.DataAccess.Entities;

namespace Reporting.DataAccess.Repositories.FilmRepositories
{
    internal class FilmRepository : IFilmRepository
    {
        private readonly ReportingContext _context;

        protected FilmRepository(ReportingContext context)
        {
            _context = context;
        }

        public void Create(Film entity)
            => _context.Add(entity);

        public async Task<Film?> GetByIdAsync(Guid id)
              => await _context.Films
            .AsNoTracking()
            .FirstOrDefaultAsync(a => a.Id == id);

        public void Update(Film entity)
             => _context.Update(entity);

        public void Delete(Guid id)
        {
            var obj = _context.Users.Find(id);
            _context.Users.Remove(obj!);
        }

        public async Task SaveChangesAsync()
           => await _context.SaveChangesAsync();
    }
}
