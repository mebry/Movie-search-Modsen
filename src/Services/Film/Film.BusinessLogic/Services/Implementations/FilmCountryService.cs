using Film.BusinessLogic.DTOs.RequestDTOs;
using Shared.Exceptions;
using Film.BusinessLogic.Exceptions.NotFound;
using Film.BusinessLogic.Extensions;
using Film.BusinessLogic.Services.Interfaces;
using Film.DataAccess.Entities;
using Film.DataAccess.Repositories.Interfaces;
using FluentValidation;
using Mapster;
using Microsoft.Extensions.Logging;
using Shared.Enums;
using Shared.Messages.GenreMessages;
using MassTransit;
using Shared.Messages.FilmCountryMessages;

namespace Film.BusinessLogic.Services.Implementations
{
    /// <summary>
    /// Service responsible for managing film countries.
    /// </summary>
    public class FilmCountryService : IFilmCountryService
    {
        private readonly IFilmCountryRepository _filmCountryRepository;
        private readonly IFilmRepository _filmRepository;
        private readonly ILogger<FilmCountryService> _logger;
        private readonly IValidator<FilmCountryRequestDTO> _validator;
        private readonly IPublishEndpoint _publishEndpoint;

        public FilmCountryService(IFilmCountryRepository filmCountryRepository, IFilmRepository filmRepository,
            ILogger<FilmCountryService> logger, IValidator<FilmCountryRequestDTO> validator, IPublishEndpoint publishEndpoint)
        {
            _filmCountryRepository = filmCountryRepository;
            _filmRepository = filmRepository;
            _logger = logger;
            _validator = validator;
            _publishEndpoint = publishEndpoint;
        }

        /// <summary>
        /// Creates a new film country association asynchronously.
        /// </summary>
        /// <param name="filmCountry">The film country association to create.</param>
        /// <exception cref="BadRequestException">Exception if the model isn't valid.></exception>
        /// <exception cref="FilmNotFoundException">Exception if the object is not found.</exception>
        public async Task CreateAsync(FilmCountryRequestDTO filmCountry)
        {
            var validationResult = await _validator.ValidateAsync(filmCountry);

            if (!validationResult.IsValid)
            {
                _logger.LogError("The model is invalid");
                throw new BadRequestException(validationResult.GetErrorMessages());
            }

            var foundFilm = await _filmRepository.GetByIdAsync(filmCountry.FilmId);

            if (foundFilm is null)
            {
                _logger.LogError("The film was not found");
                throw new FilmNotFoundException(filmCountry.FilmId);
            }

            var mappedModel = filmCountry.Adapt<FilmCountry>();

            _filmCountryRepository.Create(mappedModel);
            await _filmCountryRepository.SaveChangesAsync();

            var message = mappedModel.Adapt<CreatedFilmCountryMessage>();
            await _publishEndpoint.Publish(message);
        }

        /// <summary>
        /// Deletes a film country association asynchronously.
        /// </summary>
        /// <param name="filmId">The ID of the film.</param>
        /// <param name="countryId">The ID of the country.</param>
        /// <exception cref="FilmNotFoundException">Exception if the object is not found.</exception>
        public async Task DeleteAsync(Guid filmId, Countries countryId)
        {
            var foundFilm = await _filmRepository.GetByIdAsync(filmId);

            if (foundFilm is null)
            {
                _logger.LogError("The film was not found");
                throw new FilmNotFoundException(filmId);
            }

            _filmCountryRepository.Delete(filmId, countryId);
            await _filmCountryRepository.SaveChangesAsync();

            await _publishEndpoint.Publish(new RemovedFilmCountryMessage { CountryId = countryId, FilmId = filmId });
        }
    }
}
