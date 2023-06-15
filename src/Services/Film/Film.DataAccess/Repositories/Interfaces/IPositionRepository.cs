using Film.DataAccess.Entities;

namespace Film.DataAccess.Repositories.Interfaces
{
    /// <summary>
    /// Interface for a position repository.
    /// </summary>
    public interface IPositionRepository
    {
        /// <summary>
        /// Creates a new position.
        /// </summary>
        /// <param name="position">The position to create.</param>
        void Create(Position position);
        
        /// <summary>
        /// Updates an existing position.
        /// </summary>
        /// <param name="position">The position to update.</param>
        void Update(Position position);

        /// <summary>
        /// Saves changes asynchronously.
        /// </summary>
        /// <returns>A task that represents the asynchronous save operation.</returns>
        Task SaveChangesAsync();
    }

}
