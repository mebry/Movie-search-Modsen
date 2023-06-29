using Microsoft.EntityFrameworkCore;
using Reporting.DataAccess.Contexts;
using Reporting.DataAccess.Entities;

namespace Reporting.DataAccess.Repositories.RatingRepositories
{
    internal class RatingRepository : IRatingRepository
    {
        private readonly ReportingContext _context;

        public RatingRepository(ReportingContext context)
        {
            _context = context;
        }

        public void Create(Rating entity)
            => _context.Add(entity);

        public async Task<Rating?> GetByIdAsync(Guid id)
              => await _context.Ratings
            .AsNoTracking()
            .FirstOrDefaultAsync(a => a.Id == id);

        public void Update(Rating entity)
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
