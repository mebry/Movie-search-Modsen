using Staff.DataAccess.Entities;

namespace Staff.DataAccess.Repositories.Interfaces
{
    public interface IPositionRepository
    {
        public Task<IEnumerable<Position>> GetPositionsAsync();
        public Task<Position> GetPositionByIdAsync(Guid id);
    }
}
