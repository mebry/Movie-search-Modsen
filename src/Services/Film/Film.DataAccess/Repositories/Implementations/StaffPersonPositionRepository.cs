using Film.DataAccess.Contexts;
using Film.DataAccess.Entities;
using Film.DataAccess.Repositories.Interfaces;

namespace Film.DataAccess.Repositories.Implementations
{
    /// <summary>
    /// Repository for managing staff person positions.
    /// </summary>
    public class StaffPersonPositionRepository : IStaffPersonPositionRepository
    {
        private readonly FilmContext _context;

        public StaffPersonPositionRepository(FilmContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Creates a new staff person position.
        /// </summary>
        /// <param name="entity">The staff person position to create.</param>
        public void Create(StaffPersonPosition entity)
        {
            _context.StaffPersonPositions.Add(entity);
        }

        /// <summary>
        /// Deletes a staff person position.
        /// </summary>
        /// <param name="filmId">The Id of the film.</param>
        /// <param name="staffPersonId">The Id of the staff person.</param>
        /// <param name="positionId">The Id of the position.</param>
        public void Delete(Guid filmId, Guid staffPersonId, Guid positionId)
        {
            _context.StaffPersonPositions.Remove(new StaffPersonPosition
            {
                FilmId = filmId,
                StaffPersonId = staffPersonId,
                PositionId = positionId
            });
        }

        /// <summary>
        /// Saves the changes made to the repository asynchronously.
        /// </summary>
        /// <returns>A task that represents the asynchronous save operation.</returns>
        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }

}
