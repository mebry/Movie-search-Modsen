using Reporting.DataAccess.Entities;
using Reporting.DataAccess.Interfaces;

namespace Reporting.DataAccess.Repositories.StaffPersonPositironRepositories
{
    public interface ISatffPersonPositionRepository : ISaveChangesAsync
    {
        public void Create(StaffPersonPosition staffPerson);
        public void Delete(Guid filmId, Guid staffPersonId, Guid positionId);
    }
}
