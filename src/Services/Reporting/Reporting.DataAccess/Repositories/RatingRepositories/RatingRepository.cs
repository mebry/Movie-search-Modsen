using Microsoft.EntityFrameworkCore;
using Reporting.DataAccess.Contexts;
using Reporting.DataAccess.Entities;

namespace Reporting.DataAccess.Repositories.RatingRepositories
{
    internal class RatingRepository : EFRepository<Rating>, IRatingRepository
    {
        public RatingRepository(ReportingContext context) : base(context)
        {
        }

        public override async Task<Rating?> GetByIdAsync(Guid id)
             => await _context.Ratings
            .AsNoTracking()
            .FirstOrDefaultAsync(a => a.Id == id);
    }
}
