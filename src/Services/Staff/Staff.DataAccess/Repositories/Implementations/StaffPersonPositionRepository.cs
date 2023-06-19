using Microsoft.EntityFrameworkCore;
using Staff.DataAccess.Contexts;
using Staff.DataAccess.Entities;
using Staff.DataAccess.Repositories.Interfaces;

namespace Staff.DataAccess.Repositories.Implementations
{
    public class StaffPersonPositionRepository : IStaffPersonPositionRepository
    {
        private readonly StaffsDbContext _dbContext;

        public StaffPersonPositionRepository(StaffsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CreateAsync(StaffPersonPosition staffPersonPosition)
        {
            await _dbContext.StaffPersonPositions.AddAsync(staffPersonPosition);
        }

        public async Task<IEnumerable<Film>> GetFilmsByStaffPersonAndPositionAsync(Guid staffPersonId, Guid positionId)
        {
            return await _dbContext.StaffPersonPositions
                .Where(x => x.StaffPersonId == staffPersonId && x.PositionId == positionId)
                .Select(x => x.Film)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<StaffPersonPosition> GetPosition(Guid positionId, Guid staffPersonId, Guid filmId)
        {
            return await _dbContext.StaffPersonPositions.FindAsync(positionId, staffPersonId, filmId);
        }

        public async Task<IEnumerable<Position>> GetPositionsByStaffPersonId(Guid staffPersonId)
        {
            return await _dbContext.StaffPersonPositions
                .Where(x => x.StaffPersonId == staffPersonId)
                .Select(x => x.Position)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
