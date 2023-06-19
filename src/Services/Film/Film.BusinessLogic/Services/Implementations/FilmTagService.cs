using Film.BusinessLogic.DTOs.RequestDTOs;
using Film.BusinessLogic.Exceptions.BadRequests;
using Film.BusinessLogic.Exceptions.NotFound;
using Film.BusinessLogic.Extensions;
using Film.BusinessLogic.Services.Interfaces;
using Film.DataAccess.Entities;
using Film.DataAccess.Repositories.Implementations;
using Film.DataAccess.Repositories.Interfaces;
using FluentValidation;
using Mapster;
using Microsoft.Extensions.Logging;

namespace Film.BusinessLogic.Services.Implementations
{
    /// <summary>
    /// Service responsible for managing film tags.
    /// </summary>
    public class FilmTagService : IFilmTagService
    {
        private readonly IFilmTagRepository _filmTagRepository;
        private readonly IFilmRepository _filmRepository;
        private readonly ITagRepository _tagRepository;
        private readonly ILogger<FilmTagService> _logger;
        private readonly IValidator<FilmTagRequestDTO> _validator;

        public FilmTagService(IFilmTagRepository filmTagRepository, IFilmRepository filmRepository,
            ITagRepository tagRepository, ILogger<FilmTagService> logger, IValidator<FilmTagRequestDTO> validator)
        {
            _filmTagRepository = filmTagRepository;
            _filmRepository = filmRepository;
            _tagRepository = tagRepository;
            _logger = logger;
            _validator = validator;
        }

        /// <summary>
        /// Creates a new film tag asynchronously.
        /// </summary>
        /// <param name="filmTag">The film tag to create.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        /// <exception cref="BadRequestException">Exception if the model isn't valid.</exception>
        public async Task CreateAsync(FilmTagRequestDTO filmTag)
        {
            var validationResult = await _validator.ValidateAsync(filmTag);

            if (!validationResult.IsValid)
            {
                _logger.LogError("The model is invalid");
                throw new BadRequestException(validationResult.GetErrorMessages());
            }

            await CheckIfFilmAndTagExists(filmTag.FilmId, filmTag.TagId);

            var mappedModel = filmTag.Adapt<FilmTag>();

            _filmTagRepository.Create(mappedModel);
            await _filmTagRepository.SaveChangesAsync();
        }

        /// <summary>
        /// Deletes a film tag asynchronously.
        /// </summary>
        /// <param name="filmId">The Id of the film.</param>
        /// <param name="tagId">The Id of the tag.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        public async Task DeleteAsync(Guid filmId, Guid tagId)
        {
            await CheckIfFilmAndTagExists(filmId, tagId);

            _filmTagRepository.Delete(filmId, tagId);
            await _filmTagRepository.SaveChangesAsync();
        }

        /// <summary>
        /// Checks if a film and tag exist.
        /// </summary>
        /// <param name="filmId">The Id of the film.</param>
        /// <param name="tagId">The Id of the tag.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        /// <exception cref="FilmNotFoundException">Exception if the object is not found.</exception>
        /// <exception cref="TagNotFoundException">Exception if the object is not found.</exception>
        private async Task CheckIfFilmAndTagExists(Guid filmId, Guid tagId)
        {
            var foundFilm = await _filmRepository.GetByIdAsync(filmId);

            if (foundFilm is null)
            {
                _logger.LogError("The film was not found");
                throw new FilmNotFoundException(filmId);
            }

            var foundTag = await _tagRepository.GetByIdAsync(tagId);

            if (foundTag is null)
            {
                _logger.LogError("The tag was not found");
                throw new TagNotFoundException(tagId);
            }
        }
    }
}
