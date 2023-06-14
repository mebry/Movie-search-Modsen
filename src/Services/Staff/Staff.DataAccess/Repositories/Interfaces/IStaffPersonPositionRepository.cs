using Staff.DataAccess.Entities;

namespace Staff.DataAccess.Repositories.Interfaces
{
    public interface IStaffPersonPositionRepository
    {
        public Task<IEnumerable<Film>> GetFilmsByStaffPersonAndPositionAsync(Guid staffPersonId, Guid positionId);
        public Task CreateAsync(StaffPersonPosition staffPersonPosition);
        public Task<IEnumerable<Position>> GetPositionsByStaffPersonId(Guid staffPersonId);
        public Task<StaffPersonPosition> GetPosition(Guid positionId, Guid staffPersonId, Guid filmId);
    }
}
