using Film.BusinessLogic.DTOs.RequestDTOs;
using Film.BusinessLogic.DTOs.ResponseDTOs;
using Film.BusinessLogic.Exceptions.AlreadyExists;
using Film.BusinessLogic.Exceptions.BadRequests;
using Film.BusinessLogic.Exceptions.NotFound;
using Film.BusinessLogic.Extensions;
using Film.BusinessLogic.Services.Interfaces;
using Film.DataAccess.Entities;
using Film.DataAccess.Repositories.Interfaces;
using FluentValidation;
using Mapster;
using Microsoft.Extensions.Logging;

namespace Film.BusinessLogic.Services.Implementations
{
    /// <summary>
    /// Service responsible for managing age restrictions.
    /// </summary>
    public class AgeRestrictionService : IAgeRestrictionService
    {
        private readonly ITagRepository _tagRepository;
        private readonly IAgeRestrictionRepository _ageRestrictionRepository;
        private readonly ILogger<AgeRestrictionService> _logger;
        private readonly IValidator<AgeRestrictionRequestDTO> _validator;

        public AgeRestrictionService(IAgeRestrictionRepository ageRestrictionRepository, ILogger<AgeRestrictionService> logger, 
            IValidator<AgeRestrictionRequestDTO> validator)
        {
            _ageRestrictionRepository = ageRestrictionRepository;
            _logger = logger;
            _validator = validator;
        }

        /// <summary>
        /// Creates a new age restriction asynchronously.
        /// </summary>
        /// <param name="ageRestriction">The age restriction to create.</param>
        /// <returns>The created age restriction response DTO.</returns>
        /// <exception cref="BadRequestException">Exception if the model isn't valid.></exception>
        /// <exception cref="AgeRestrictionAlreadyExistsException">Exception if the object is found.</exception>
        public async Task<AgeRestrictionResponseDTO> CreateAsync(AgeRestrictionRequestDTO ageRestriction)
        {
            var validationResult = await _validator.ValidateAsync(ageRestriction);

            if (!validationResult.IsValid)
            {
                _logger.LogError("The model is invalid");
                throw new BadRequestException(validationResult.GetErrorMessages());
            }

            var foundRestriction = await _ageRestrictionRepository.GetAgeRestrictionByAgeAsync(ageRestriction.Age);

            if (foundRestriction is not null)
            {
                _logger.LogError("The model could not be created because such a model already exists");
                throw new AgeRestrictionAlreadyExistsException();
            }

            var mappedModel = ageRestriction.Adapt<AgeRestriction>();
            mappedModel.Id = Guid.NewGuid();

            _ageRestrictionRepository.Create(mappedModel);
            await _ageRestrictionRepository.SaveChangesAsync();

            return mappedModel.Adapt<AgeRestrictionResponseDTO>();
        }

        /// <summary>
        /// Deletes an age restriction asynchronously.
        /// </summary>
        /// <param name="id">The ID of the age restriction to delete.</param>
        /// <exception cref="AgeRestrictionNotFoundException">Exception if the object is not found.</exception>
        public async Task DeleteAsync(Guid id)
        {
            var foundAgeRestriction = await _ageRestrictionRepository.GetByIdAsync(id);

            if (foundAgeRestriction is null)
            {
                _logger.LogError("The model for the delete was not found");
                throw new AgeRestrictionNotFoundException(id);
            }

            _ageRestrictionRepository.Delete(id);

            await _ageRestrictionRepository.SaveChangesAsync();
        }

        /// <summary>
        /// Retrieves all age restrictions asynchronously.
        /// </summary>
        /// <returns>A collection of age restriction response DTOs.</returns>
        public async Task<IEnumerable<AgeRestrictionResponseDTO>> GetAgeRestrictionsAsync()
        {
            var foundData = await _ageRestrictionRepository.GetAgeRestrictionsAsync();

            return foundData.Adapt<List<AgeRestrictionResponseDTO>>();
        }

        /// <summary>
        /// Retrieves an age restriction by ID asynchronously.
        /// </summary>
        /// <param name="id">The ID of the age restriction to retrieve.</param>
        /// <returns>The age restriction response DTO.</returns>
        /// <exception cref="AgeRestrictionNotFoundException">Exception if the object is not found.</exception>
        public async Task<AgeRestrictionResponseDTO> GetByIdAsync(Guid id)
        {
            var foundAgeRestriction = await _ageRestrictionRepository.GetByIdAsync(id);

            if (foundAgeRestriction is null)
            {
                _logger.LogError("The model for the get was not found");
                throw new AgeRestrictionNotFoundException(id);
            }

            return foundAgeRestriction.Adapt<AgeRestrictionResponseDTO>();
        }

        /// <summary>
        /// Retrieves an age restriction by age asynchronously.
        /// </summary>
        /// <param name="age">The age to search for.</param>
        /// <returns>The age restriction response DTO.</returns>
        /// <exception cref="NotFoundException">Exception if the object is not found.</exception>
        public async Task<AgeRestrictionResponseDTO> GetAgeRestrictionByAgeAsync(int age)
        {
            var foundAgeRestriction = await _ageRestrictionRepository.GetAgeRestrictionByAgeAsync(age);

            if (foundAgeRestriction is null)
            {
                _logger.LogError("The model for the get was not found");
                throw new NotFoundException("The age restriction with this age wasn't found");
            }

            return foundAgeRestriction.Adapt<AgeRestrictionResponseDTO>();
        }

        /// <summary>
        /// Updates an age restriction asynchronously.
        /// </summary>
        /// <param name="id">The ID of the age restriction to update.</param>
        /// <param name="ageRestriction">The updated age restriction.</param>
        /// <exception cref="BadRequestException">Exception if the model isn't valid.</exception>
        /// <exception cref="NotFoundException">Exception if the object is not found.</exception>
        public async Task UpdateAsync(Guid id, AgeRestrictionRequestDTO ageRestriction )
        {
            var validationResult = await _validator.ValidateAsync(ageRestriction);

            if (!validationResult.IsValid)
            {
                _logger.LogError("The model is invalid");
                throw new BadRequestException(validationResult.GetErrorMessages());
            }

            var foundAgeRestriction = await _ageRestrictionRepository.GetByIdAsync(id);

            if (foundAgeRestriction is null)
            {
                _logger.LogError("The model for the update was not found");
                throw new AgeRestrictionNotFoundException(id);
            }
            var mappedModel = ageRestriction.Adapt<AgeRestriction>();

            mappedModel.Id = Guid.NewGuid();

            _ageRestrictionRepository.Update(mappedModel);

            await _ageRestrictionRepository.SaveChangesAsync();
        }
    }
}
