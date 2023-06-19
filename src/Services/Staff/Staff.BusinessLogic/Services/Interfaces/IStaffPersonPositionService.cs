using Staff.BusinessLogic.DTOs;

namespace Staff.BusinessLogic.Services.Interfaces
{
    public interface IStaffPersonPositionService
    {
        public Task<IEnumerable<ResponseFilmDTO>> GetFilmsByStaffPersonAndPositionAsync(Guid staffPersonId, Guid positionId);
        public Task<StaffPersonPositionDTO> CreateAsync(Guid staffPersonId, Guid positionId, Guid filmId);
        public Task<IEnumerable<ResponsePositionDTO>> GetPositionsByStaffPersonIdAsync(Guid staffPersonId);
    }
}
