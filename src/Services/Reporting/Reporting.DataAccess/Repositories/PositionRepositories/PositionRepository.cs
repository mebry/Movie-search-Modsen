using Microsoft.EntityFrameworkCore;
using Reporting.DataAccess.Contexts;
using Reporting.DataAccess.Entities;

namespace Reporting.DataAccess.Repositories.PositionRepositories
{
    internal class PositionRepository : IPositionRepository
    {
        private readonly ReportingContext _context;

        protected PositionRepository(ReportingContext context)
        {
            _context = context;
        }

        public void Create(Position entity)
            => _context.Add(entity);

        public async Task<Position?> GetByIdAsync(Guid id)
              => await _context.Positions
            .AsNoTracking()
            .FirstOrDefaultAsync(a => a.Id == id);

        public void Update(Position entity)
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
