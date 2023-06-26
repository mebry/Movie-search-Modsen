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
using MassTransit;
using Shared.Messages.FilmMessages;

namespace Film.BusinessLogic.Services.Implementations
{
    /// <summary>
    /// Service responsible for managing films.
    /// </summary>
    public class FilmService : IFilmService
    {
        private readonly IFilmRepository _filmRepository;
        private readonly ILogger<FilmService> _logger;
        private readonly IValidator<FilmRequestDTO> _validator;
        private readonly TypeAdapterConfig _typeAdapterConfig;
        private readonly IPublishEndpoint _publishEndpoint;

        public FilmService(IFilmRepository filmRepository, ILogger<FilmService> logger, IValidator<FilmRequestDTO> validator,
            TypeAdapterConfig typeAdapterConfig, IPublishEndpoint publishEndpoint)
        {
            _filmRepository = filmRepository;
            _logger = logger;
            _validator = validator;
            _typeAdapterConfig = typeAdapterConfig;
            _publishEndpoint = publishEndpoint;
        }

        /// <summary>
        /// Creates a new film asynchronously.
        /// </summary>
        /// <param name="film">The film to create.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        /// <exception cref="BadRequestException">Exception if the model isn't valid.></exception>
        /// <exception cref="FilmAlreadyExistsException">Exception if the model is found.</exception>
        public async Task<FilmResponseDTO> CreateAsync(FilmRequestDTO film)
        {
            var validationResult = await _validator.ValidateAsync(film);

            if (!validationResult.IsValid)
            {
                _logger.LogError("The model is invalid");
                throw new BadRequestException(validationResult.GetErrorMessages());
            }

            var foundFilm = await _filmRepository.FilmExistsAsync(film.Title, film.ReleaseDate);

            if (foundFilm)
            {
                _logger.LogError("The model could not be created because such a model already exists");
                throw new FilmAlreadyExistsException();
            }

            var mappedModel = film.Adapt<FilmModel>();
            mappedModel.Id = Guid.NewGuid();

            _filmRepository.Create(mappedModel);

            var message = mappedModel.Adapt<CreatedFilmMessage>();
            await _publishEndpoint.Publish(message);

            await _filmRepository.SaveChangesAsync();

            return mappedModel.Adapt<FilmResponseDTO>();
        }

        /// <summary>
        /// Deletes a film asynchronously.
        /// </summary>
        /// <param name="id">The ID of the film to delete.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        /// <exception cref="FilmNotFoundException">Exception if the object is not found.</exception>
        public async Task DeleteAsync(Guid id)
        {
            var foundFilm = await _filmRepository.GetByIdAsync(id);

            if (foundFilm is null)
            {
                _logger.LogError("The model for the delete was not found");
                throw new FilmNotFoundException(id);
            }

            _filmRepository.Delete(id);

            await _publishEndpoint.Publish(new RemovedFilmMessage { Id = id });

            await _filmRepository.SaveChangesAsync();
        }

        /// <summary>
        /// Retrieves a paged list of films asynchronously.
        /// </summary>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="filterQueryString">The filter query string.</param>
        /// <param name="orderByQueryString">The order by query string.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        /// <exception cref="BadRequestException">Exception if the model isn't valid.></exception>
        public async Task<IEnumerable<FilmResponseDTO>> GetFilmsAsync(int pageNumber, int pageSize, string filterQueryString,
            string orderByQueryString)
        {
            if (pageNumber <= 0)
            {
                var message = "The page number must be greater than 0";
                _logger.LogError(message);
                throw new BadRequestException(message);
            }

            if (pageSize <= 0)
            {
                var message = "The page size must be greater than 0";
                _logger.LogError(message);
                throw new BadRequestException("The page size must be greater than 0");
            }

            var foundFilms = await _filmRepository.GetFilmsAsync(pageNumber, pageSize, filterQueryString, orderByQueryString);

            return foundFilms.Adapt<List<FilmResponseDTO>>(_typeAdapterConfig);
        }

        /// <summary>
        /// Retrieves a film by Id asynchronously.
        /// </summary>
        /// <param name="id">The Id of the film.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        /// <exception cref="FilmNotFoundException">Exception if the object is not found.</exception>
        public async Task<FilmResponseDTO> GetByIdAsync(Guid id)
        {
            var foundFilm = await _filmRepository.GetByIdAsync(id);

            if (foundFilm is null)
            {
                _logger.LogError("The film was not found");
                throw new FilmNotFoundException(id);
            }

            return foundFilm.Adapt<FilmResponseDTO>(_typeAdapterConfig);
        }

        /// <summary>
        /// Updates a film asynchronously.
        /// </summary>
        /// <param name="id">The ID of the film to update.</param>
        /// <param name="tag">The updated film data.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        /// <exception cref="BadRequestException">Exception if the model isn't valid.></exception>
        /// <exception cref="FilmNotFoundException">Exception if the object is not found.</exception>
        public async Task UpdateAsync(Guid id, FilmRequestDTO tag)
        {
            var validationResult = await _validator.ValidateAsync(tag);

            if (!validationResult.IsValid)
            {
                _logger.LogError("The model is invalid");
                throw new BadRequestException(validationResult.GetErrorMessages());
            }

            var foundFilm = await _filmRepository.GetByIdAsync(id);

            if (foundFilm is null)
            {
                _logger.LogError("The film was not found");
                throw new FilmNotFoundException(id);
            }
            var mappedModel = tag.Adapt<FilmModel>();

            mappedModel.Id = id;

            _filmRepository.Update(mappedModel);

            var message = mappedModel.Adapt<UpdatedFilmMessage>();
            await _publishEndpoint.Publish(message);

            await _filmRepository.SaveChangesAsync();
        }
    }
}
