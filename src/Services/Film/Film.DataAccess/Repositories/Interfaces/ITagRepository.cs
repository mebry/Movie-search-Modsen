using Film.DataAccess.Entities;

namespace Film.DataAccess.Repositories.Interfaces
{
    /// <summary>
    /// Interface for a tag repository.
    /// </summary>
    public interface ITagRepository : IRepository<Tag>
    {
        /// <summary>
        /// Retrieves all tags.
        /// </summary>
        /// <returns>An enumeration of tags.</returns>
        Task<IEnumerable<Tag>> GetTags();
    }
}
