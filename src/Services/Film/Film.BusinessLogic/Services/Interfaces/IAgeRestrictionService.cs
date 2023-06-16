using Film.BusinessLogic.DTOs.RequestDTOs;
using Film.BusinessLogic.DTOs.ResponseDTOs;
using System.Reflection.Metadata;

namespace Film.BusinessLogic.Services.Interfaces
{
    /// <summary>
    /// Service interface for age restrictions.
    /// </summary>
    public interface IAgeRestrictionService
    {
        /// <summary>
        /// Creates a new age restriction.
        /// </summary>
        /// <param name="ageRestriction">The age restriction data.</param>
        /// <returns>A task representing the asynchronous operation. The result contains the created data.</returns>
        Task<AgeRestrictionResponseDTO> CreateAsync(AgeRestrictionRequestDTO ageRestriction);

        /// <summary>
        /// Retrieves an age restriction by its ID.
        /// </summary>
        /// <param name="id">The ID of the age restriction.</param>
        /// <returns>A task representing the asynchronous operation.
        /// The task result contains the age restriction data.</returns>
        Task<AgeRestrictionResponseDTO> GetByIdAsync(Guid id);

        /// <summary>
        /// Updates an existing age restriction.
        /// </summary>
        /// <param name="id">The ID of the age restriction to update.</param>
        /// <param name="ageRestriction">The updated age restriction data.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task UpdateAsync(Guid id, AgeRestrictionRequestDTO ageRestriction);

        /// <summary>
        /// Deletes an age restriction.
        /// </summary>
        /// <param name="id">The ID of the age restriction to delete.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task DeleteAsync(Guid id);

        /// <summary>
        /// Retrieves all age restrictions.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.
        /// The task result contains a collection of age restriction data.</returns>
        Task<IEnumerable<AgeRestrictionResponseDTO>> GetAgeRestrictionsAsync();

        /// <summary>
        /// Retrieves an age restriction by its age value.
        /// </summary>
        /// <param name="age">The age value of the age restriction.</param>
        /// <returns>A task representing the asynchronous operation.
        /// The task result contains the age restriction data.</returns>
        Task<AgeRestrictionResponseDTO> GetAgeRestrictionByAgeAsync(int age);
    }
}
