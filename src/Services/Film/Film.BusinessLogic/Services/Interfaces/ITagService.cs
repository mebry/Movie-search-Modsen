using Film.BusinessLogic.DTOs.RequestDTOs;
using Film.BusinessLogic.DTOs.ResponseDTOs;

namespace Film.BusinessLogic.Services.Interfaces
{
    /// <summary>
    /// Service interface for tags.
    /// </summary>
    public interface ITagService
    {
        /// <summary>
        /// Creates a new tag.
        /// </summary>
        /// <param name="tag">The tag data.</param>
        /// <returns>A task representing the asynchronous operation. The result contains the created data.</returns>
        Task<TagResponseDTO> CreateAsync(TagRequestDTO tag);

        /// <summary>
        /// Retrieves a tag by its ID.
        /// </summary>
        /// <param name="id">The ID of the tag.</param>
        /// <returns>A task representing the asynchronous operation. The result contains the tag data.</returns>
        Task<TagResponseDTO> GetByIdAsync(Guid id);

        /// <summary>
        /// Updates a tag.
        /// </summary>
        /// <param name="id">The ID of the tag.</param>
        /// <param name="tag">The updated tag data.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task UpdateAsync(Guid id, TagRequestDTO tag);

        /// <summary>
        /// Deletes a tag.
        /// </summary>
        /// <param name="id">The ID of the tag to delete.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task DeleteAsync(Guid id);

        /// <summary>
        /// Retrieves tags by name.
        /// </summary>
        /// <param name="name">The name of the tags to retrieve.</param>
        /// <returns>A task representing the asynchronous operation. The result contains a tag.</returns>
        Task<TagResponseDTO> GetByNameAsync(string name);

        /// <summary>
        /// Retrieves all tags.
        /// </summary>
        /// <returns>A task representing the asynchronous operation that returns a collection of TagResponseDTO objects.</returns>
        Task<IEnumerable<TagResponseDTO>> GetAllAsync();
    }
}
