using Microsoft.EntityFrameworkCore;
using Reporting.DataAccess.Contexts;
using Reporting.DataAccess.Entities;

namespace Reporting.DataAccess.Repositories.GenreRepositories
{
    internal class GenreRepository : EFRepository<Genre>, IGenreRepository
    {
        public GenreRepository(ReportingContext context) : base(context)
        {
        }

        public override async Task<Genre?> GetByIdAsync(Guid id)
             => await _context.Genres
            .AsNoTracking()
            .FirstOrDefaultAsync(a => a.Id == id);
    }
}
