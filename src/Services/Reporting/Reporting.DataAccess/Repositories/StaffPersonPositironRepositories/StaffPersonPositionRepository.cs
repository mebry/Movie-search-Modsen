using Microsoft.EntityFrameworkCore;
using Reporting.DataAccess.Contexts;
using Reporting.DataAccess.Entities;

namespace Reporting.DataAccess.Repositories.StaffPersonPositironRepositories
{
    internal class StaffPersonPositionRepository : IStaffPersonPositionRepository
    {
        private readonly ReportingContext _context;

        public StaffPersonPositionRepository(ReportingContext context)
        {
            _context = context;
        }

        public void Create(StaffPersonPosition entity)
            => _context.StaffPersonPositions.Add(entity);

        public void Delete(Guid filmId, Guid staffPersonId, Guid positionId)
            => _context.StaffPersonPositions.Remove(
                new StaffPersonPosition
                {
                    FilmId = filmId,
                    StaffPersonId = staffPersonId,
                    PositionId = positionId
                });

        public async Task<IEnumerable<StaffPersonPosition>> GetAllByStaffPersonId(Guid staffPersonId)
            => await _context.StaffPersonPositions
                .AsNoTracking()
                .Where(s => s.StaffPersonId == staffPersonId)
                .Include(s => s.Film)
                .Include(s => s.Position)
                .ToListAsync();

        public async Task SaveChangesAsync()
            => await _context.SaveChangesAsync();
    }
}
