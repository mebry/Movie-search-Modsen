using Microsoft.EntityFrameworkCore;
using Reporting.DataAccess.Contexts;
using Reporting.DataAccess.Entities;

namespace Reporting.DataAccess.Repositories.GenreRepositories
{
    internal class GenreRepository : IGenreRepository
    {
        private readonly ReportingContext _context;

        protected GenreRepository(ReportingContext context)
        {
            _context = context;
        }

        public void Create(Genre entity)
            => _context.Add(entity);

        public async Task<Genre?> GetByIdAsync(Guid id)
              => await _context.Genres
            .AsNoTracking()
            .FirstOrDefaultAsync(a => a.Id == id);

        public void Update(Genre entity)
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
