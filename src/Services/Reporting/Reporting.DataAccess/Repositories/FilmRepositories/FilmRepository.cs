using Microsoft.EntityFrameworkCore;
using Reporting.DataAccess.Contexts;
using Reporting.DataAccess.Entities;

namespace Reporting.DataAccess.Repositories.FilmRepositories
{
    internal class FilmRepository : EFRepository<Film>, IFilmRepository
    {
        public FilmRepository(ReportingContext context) : base(context)
        {
        }

        public override async Task<Film?> GetByIdAsync(Guid id)
              => await _context.Films
            .AsNoTracking()
            .FirstOrDefaultAsync(a => a.Id == id);
    }
}
