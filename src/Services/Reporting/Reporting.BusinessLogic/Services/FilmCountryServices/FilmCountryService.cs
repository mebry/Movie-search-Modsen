using Mapster;
using Microsoft.Extensions.Logging;
using Reporting.BusinessLogic.DTOs.ConsumerDTOs;
using Reporting.DataAccess.Entities;
using Reporting.DataAccess.Repositories.FilmCountryRepositories;
using Reporting.DataAccess.Repositories.FilmRepositories;
using Shared.Enums;
using Shared.Exceptions;

namespace Reporting.BusinessLogic.Services.FilmCountryServices
{
    internal class FilmCountryService : IFilmCountryReportingService, IFilmCountryDataCaptureService
    {
        private readonly IFilmCountryRepository _filmCountryRepository;
        private readonly IFilmRepository _filmRepository;
        private readonly ILogger<FilmCountryService> _logger;

        public FilmCountryService(IFilmCountryRepository filmCountryRepository, IFilmRepository filmRepository,
            ILogger<FilmCountryService> logger)
        {
            _filmCountryRepository = filmCountryRepository;
            _filmRepository = filmRepository;
            _logger = logger;
        }

        public async Task Create(ConsumerFilmCountryDTO filmCountry)
        {
            var existingFilm = await _filmRepository.GetByIdAsync(filmCountry.FilmId);

            if(existingFilm is null)
            {
                _logger.LogError("The film was not found");

                throw new NotFoundException("The film was not found");
            }

            var mapperModel = filmCountry.Adapt<FilmCountry>();
            _filmCountryRepository.Create(mapperModel);

            await _filmCountryRepository.SaveChangesAsync();
        }

        public async Task Delete(Guid filmId, Countries countryEnum)
        {
            var existingFilm = await _filmRepository.GetByIdAsync(filmId);

            if(existingFilm is null)
            {
                _logger.LogError("The film was not found");

                throw new NotFoundException("The film was not found");
            }

            _filmCountryRepository.Delete(filmId, countryEnum);

            await _filmCountryRepository.SaveChangesAsync();
        }
    }
}
