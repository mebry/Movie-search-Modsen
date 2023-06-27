using Reporting.DataAccess.Contexts;
using Reporting.DataAccess.Entities;

namespace Reporting.DataAccess.Repositories.StaffPersonPositironRepositories
{
    internal class SatffPersonPositionRepository : ISatffPersonPositionRepository
    {
        private readonly ReportingContext _context;

        public SatffPersonPositionRepository(ReportingContext context)
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


        public async Task SaveChangesAsync()
            => await _context.SaveChangesAsync();
    }
}
