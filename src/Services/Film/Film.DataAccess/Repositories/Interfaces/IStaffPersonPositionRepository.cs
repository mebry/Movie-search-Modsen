using Film.DataAccess.Entities;

namespace Film.DataAccess.Repositories.Interfaces
{
    /// <summary>
    /// Interface for a staff person position repository.
    /// </summary>
    public interface IStaffPersonPositionRepository
    {
        /// <summary>
        /// Creates a new staff person position.
        /// </summary>
        /// <param name="staffPerson">The staff person position to create.</param>
        void Create(StaffPersonPosition staffPerson);

        /// <summary>
        /// Deletes a staff person position.
        /// </summary>
        /// <param name="filmId">The ID of the film associated with the staff person position.</param>
        /// <param name="staffPersonId">The ID of the staff person associated with the staff person position.</param>
        /// <param name="positionId">The ID of the position associated with the staff person position.</param>
        void Delete(Guid filmId, Guid staffPersonId, Guid positionId);

        /// <summary>
        /// Saves changes asynchronously.
        /// </summary>
        /// <returns>A task that represents the asynchronous save operation.</returns>
        Task SaveChangesAsync();
    }
}
