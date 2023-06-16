using Film.DataAccess.Contexts;
using Film.DataAccess.Entities;
using Film.DataAccess.Repositories.Interfaces;

namespace Film.DataAccess.Repositories.Implementations
{
    /// <summary>
    /// Repository for managing film positions.
    /// </summary>
    public class PositionRepository : IPositionRepository
    {
        private readonly FilmContext _context;

        public PositionRepository(FilmContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Creates a new film position.
        /// </summary>
        /// <param name="position">The position to create.</param>
        public void Create(Position position)
        {
            _context.Positions.Add(position);
        }

        /// <summary>
        /// Updates an existing film position.
        /// </summary>
        /// <param name="position">The position to update.</param>
        public void Update(Position position)
        {
            _context.Positions.Update(position);
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
