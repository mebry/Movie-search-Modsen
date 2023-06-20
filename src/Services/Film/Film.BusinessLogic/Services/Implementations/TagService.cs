using Film.BusinessLogic.DTOs.RequestDTOs;
using Film.BusinessLogic.DTOs.ResponseDTOs;
using Film.BusinessLogic.Exceptions.AlreadyExists;
using Shared.Exceptions;
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
    /// Service responsible for managing tags.
    /// </summary>
    public class TagService : ITagService
    {
        private readonly ITagRepository _tagRepository;
        private readonly ILogger<TagService> _logger;
        private readonly IValidator<TagRequestDTO> _validator;

        public TagService(ITagRepository tagRepository, ILogger<TagService> logger, IValidator<TagRequestDTO> validator)
        {
            _tagRepository = tagRepository;
            _logger = logger;
            _validator = validator;
        }

        /// <summary>
        /// Creates a new tag asynchronously.
        /// </summary>
        /// <param name="tag">The tag to create.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        /// <exception cref="BadRequestException">Exception if the model isn't valid.</exception>
        /// <exception cref="TagAlreadyExistsException">Exception if the object is found.</exception>
        public async Task<TagResponseDTO> CreateAsync(TagRequestDTO tag)
        {
            var validationResult = await _validator.ValidateAsync(tag);

            if (!validationResult.IsValid)
            {
                _logger.LogError("The model is invalid");
                throw new BadRequestException(validationResult.GetErrorMessages());
            }

            var foundTag = _tagRepository.GetTagByNameAsync(tag.Name);

            if (foundTag is not null)
            {
                _logger.LogError("The model could not be created because such a model already exists");
                throw new TagAlreadyExistsException();
            }

            var mappedModel = tag.Adapt<Tag>();
            mappedModel.Id = Guid.NewGuid();

            _tagRepository.Create(mappedModel);
            await _tagRepository.SaveChangesAsync();

            return mappedModel.Adapt<TagResponseDTO>();
        }

        /// <summary>
        /// Deletes a tag asynchronously.
        /// </summary>
        /// <param name="id">The Id of the tag to delete.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        /// <exception cref="TagNotFoundException">Exception if the object is not found.</exception>
        public async Task DeleteAsync(Guid id)
        {
            var foundTag = await _tagRepository.GetByIdAsync(id);

            if (foundTag is null)
            {
                _logger.LogError("The tag was not found");
                throw new TagNotFoundException(id);
            }

            _tagRepository.Delete(id);

            await _tagRepository.SaveChangesAsync();
        }

        /// <summary>
        /// Gets all tags asynchronously.
        /// </summary>
        /// <returns>A task that represents the asynchronous operation.</returns>
        public async Task<IEnumerable<TagResponseDTO>> GetAllAsync()
        {
            var foundTags = await _tagRepository.GetTagsAsync();

            return foundTags.Adapt<List<TagResponseDTO>>();
        }

        /// <summary>
        /// Gets a tag by Id asynchronously.
        /// </summary>
        /// <param name="id">The Id of the tag.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        /// <exception cref="TagNotFoundException">Exception if the object is not found.</exception>
        public async Task<TagResponseDTO> GetByIdAsync(Guid id)
        {
            var foundTag = await _tagRepository.GetByIdAsync(id);

            if (foundTag is null)
            {
                _logger.LogError("The tag was not found");
                throw new TagNotFoundException(id);
            }

            return foundTag.Adapt<TagResponseDTO>();
        }

        /// <summary>
        /// Gets a tag by name asynchronously.
        /// </summary>
        /// <param name="name">The name of the tag.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        /// <exception cref="NotFoundException">Exception if the object is not found.</exception>
        public async Task<TagResponseDTO> GetByNameAsync(string name)
        {
            var foundTag = await _tagRepository.GetTagByNameAsync(name);

            if (foundTag is null)
            {
                _logger.LogError("The tag was not found");
                throw new NotFoundException("The tag with this name wasn't found");
            }

            return foundTag.Adapt<TagResponseDTO>();
        }

        /// <summary>
        /// Updates a tag asynchronously.
        /// </summary>
        /// <param name="id">The Id of the tag to update.</param>
        /// <param name="tag">The updated tag data.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        /// <exception cref="BadRequestException">Exception if the model isn't valid.</exception>
        /// <exception cref="TagNotFoundException">Exception if the object is not found.</exception>
        public async Task UpdateAsync(Guid id, TagRequestDTO tag)
        {
            var validationResult = await _validator.ValidateAsync(tag);

            if (!validationResult.IsValid)
            {
                _logger.LogError("The model is invalid");
                throw new BadRequestException(validationResult.GetErrorMessages());
            }

            var foundTag = await _tagRepository.GetByIdAsync(id);

            if (foundTag is null)
            {
                _logger.LogError("The tag was not found");
                throw new TagNotFoundException(id);
            }
            var mappedModel = tag.Adapt<Tag>();

            mappedModel.Id = Guid.NewGuid();

            _tagRepository.Update(mappedModel);

            await _tagRepository.SaveChangesAsync();
        }
    }
}
