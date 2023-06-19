using Film.DataAccess.Contexts;
using Film.DataAccess.Entities;
using Film.DataAccess.Repositories.Interfaces;

namespace Film.DataAccess.Repositories.Implementations
{
    /// <summary>
    /// Repository for managing staff persons.
    /// </summary>
    public class StaffPersonRepository : IStaffPersonRepository
    {
        private readonly FilmContext _context;

        public StaffPersonRepository(FilmContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Creates a new staff person.
        /// </summary>
        /// <param name="entity">The staff person to create.</param>
        public void Create(StaffPerson entity)
        {
            _context.StaffPersons.Add(entity);
        }

        /// <summary>
        /// Deletes a staff person by ID.
        /// </summary>
        /// <param name="id">The ID of the staff person to delete.</param>
        public void Delete(Guid id)
        {
            _context.StaffPersons.Remove(new StaffPerson { Id = id });
        }

        /// <summary>
        /// Saves the changes made to the repository asynchronously.
        /// </summary>
        /// <returns>A task that represents the asynchronous save operation.</returns>
        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Updates a staff person.
        /// </summary>
        /// <param name="entity">The staff person to update.</param>
        public void Update(StaffPerson entity)
        {
            _context.StaffPersons.Update(entity);
        }
    }
}
