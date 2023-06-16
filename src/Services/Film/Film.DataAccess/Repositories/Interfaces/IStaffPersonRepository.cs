using Film.DataAccess.Entities;

namespace Film.DataAccess.Repositories.Interfaces
{
    /// <summary>
    /// Interface for a staff person repository.
    /// </summary>
    public interface IStaffPersonRepository
    {
        /// <summary>
        /// Creates a new staff person.
        /// </summary>
        /// <param name="staffPerson">The staff person to create.</param>
        void Create(StaffPerson staffPerson);

        /// <summary>
        /// Updates an existing staff person.
        /// </summary>
        /// <param name="staffPerson">The staff person to update.</param>
        void Update(StaffPerson staffPerson);

        /// <summary>
        /// Deletes a staff person by ID.
        /// </summary>
        /// <param name="id">The ID of the staff person to delete.</param>
        void Delete(Guid id);

        /// <summary>
        /// Saves changes asynchronously.
        /// </summary>
        /// <returns>A task that represents the asynchronous save operation.</returns>
        Task SaveChangesAsync();
    }
}
