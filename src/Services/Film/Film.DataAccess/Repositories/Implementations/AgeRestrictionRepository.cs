using Film.DataAccess.Contexts;
using Film.DataAccess.Entities;
using Film.DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Film.DataAccess.Repositories.Implementations
{
    /// <summary>
    /// Repository class for managing age restrictions.
    /// </summary>
    public class AgeRestrictionRepository : IAgeRestrictionRepository
    {
        private readonly FilmContext _context;

        public AgeRestrictionRepository(FilmContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Creates a new age restriction entity.
        /// </summary>
        /// <param name="entity">The age restriction entity to create.</param>
        public void Create(AgeRestriction entity)
        {
            _context.AgeRestrictions.Add(entity);
        }

        /// <summary>
        /// Deletes an age restriction entity by Id.
        /// </summary>
        /// <param name="id">The Id of the age restriction entity to delete.</param>
        public void Delete(Guid id)
        {
            _context.AgeRestrictions.Remove(new AgeRestriction { Id = id });
        }

        /// <summary>
        /// Retrieves an age restriction entity by Id asynchronously.
        /// </summary>
        /// <param name="id">The Id of the age restriction entity to retrieve.</param>
        /// <returns>The task result contains the age restriction entity if found; otherwise, null.</returns>
        public async Task<AgeRestriction> GetByIdAsync(Guid id)
        {
            var ageRestriction = await _context.AgeRestrictions.AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);

            return ageRestriction;
        }

        /// <summary>
        /// Retrieves an age restriction entity by age asynchronously.
        /// </summary>
        /// <param name="age">The age of the age restriction entity to retrieve.</param>
        /// <returns>The task result contains the age restriction entity if found; otherwise, null.</returns>
        public async Task<AgeRestriction> GetAgeRestrictionByAgeAsync(int age)
        {
            var ageRestriction = await _context.AgeRestrictions.AsNoTracking()
                .FirstOrDefaultAsync(x => x.Age == age);

            return ageRestriction;
        }

        /// <summary>
        /// Retrieves all age restriction entities asynchronously.
        /// </summary>
        /// <returns>The task result contains the list of age restriction entities.</returns>
        public async Task<IEnumerable<AgeRestriction>> GetAgeRestrictionsAsync()
        {
            var ageRestrictions = await _context.AgeRestrictions.AsNoTracking()
                .ToListAsync();

            return ageRestrictions;
        }

        /// <summary>
        /// Saves the changes made to the context asynchronously.
        /// </summary>
        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Updates an existing age restriction entity.
        /// </summary>
        /// <param name="entity">The age restriction entity to update.</param>
        public void Update(AgeRestriction entity)
        {
            _context.AgeRestrictions.Update(entity);
        }
    }
}
