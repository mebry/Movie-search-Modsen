using Film.DataAccess.Entities;

namespace Film.DataAccess.Repositories.Interfaces
{
    /// <summary>
    /// Interface for an age restriction repository, extending the generic IRepository interface for AgeRestriction entities.
    /// </summary>
    public interface IAgeRestrictionRepository : IRepository<AgeRestriction>
    {
        /// <summary>
        /// Retrieves all age restrictions.
        /// </summary>
        /// <returns>A task that represents the asynchronous operation and contains the collection of age restrictions.</returns>
        Task<IEnumerable<AgeRestriction>> GetAgeRestrictionsAsync();

        /// <summary>
        /// Retrieves an age restriction entity by age asynchronously.
        /// </summary>
        /// <param name="age">The age to search for.</param>
        /// <returns> The task result contains the age restriction entity if found; otherwise, null.</returns>
        Task<AgeRestriction> GetAgeRestrictionByAgeAsync(int age);
    }
}
