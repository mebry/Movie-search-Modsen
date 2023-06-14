using Microsoft.EntityFrameworkCore;
using Staff.DataAccess.Contexts;
using Staff.DataAccess.Entities;
using Staff.DataAccess.Repositories.Interfaces;

namespace Staff.DataAccess.Repositories.Implementations
{
    public class PositionRepository : IPositionRepository
    {
        private readonly StaffsDbContext _dbContext;

        public PositionRepository(StaffsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Position> GetPositionByIdAsync(Guid id)
        {
            return await _dbContext.Positions.FindAsync(id);
        }

        public async Task<IEnumerable<Position>> GetPositionsAsync()
        {
            return await _dbContext.Positions
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
