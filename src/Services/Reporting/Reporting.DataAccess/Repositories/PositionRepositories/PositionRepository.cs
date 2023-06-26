using Microsoft.EntityFrameworkCore;
using Reporting.DataAccess.Contexts;
using Reporting.DataAccess.Entities;

namespace Reporting.DataAccess.Repositories.PositionRepositories
{
    internal class PositionRepository : EFRepository<Position>, IPostionRepository
    {
        public PositionRepository(ReportingContext context) : base(context)
        {
        }

        public override async Task<Position?> GetByIdAsync(Guid id)
             => await _context.Positions
            .AsNoTracking()
            .FirstOrDefaultAsync(a => a.Id == id);
    }
}
