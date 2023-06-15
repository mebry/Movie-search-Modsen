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
        Task<IEnumerable<Tag>> GetTagsAsync();

        /// <summary>
        /// Retrieves a tag entity by its name asynchronously.
        /// </summary>
        /// <param name="name">The name of the tag to retrieve.</param>
        /// <returns>A task representing the asynchronous operation that returns the tag entity.</returns>
        Task<Tag> GetTagByNameAsync(string name);
    }
}
