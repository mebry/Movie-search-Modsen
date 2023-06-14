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
        Task<IEnumerable<AgeRestriction>> GetAgeRestrictions();
    }
}
