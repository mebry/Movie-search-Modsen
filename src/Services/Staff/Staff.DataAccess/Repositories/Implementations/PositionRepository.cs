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

        public async Task CreateAsync(Position position)
        {
            await _dbContext.Positions.AddAsync(position);
        }

        public async Task<Position> GetPositionByIdAsync(Guid id)
        {
            return await _dbContext.Positions.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Position>> GetPositionsAsync()
        {
            return await _dbContext.Positions
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
