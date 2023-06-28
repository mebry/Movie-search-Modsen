using Mapster;
using Microsoft.Extensions.Logging;
using Reporting.BusinessLogic.DTOs.ConsumerDTOs;
using Reporting.DataAccess.Entities;
using Reporting.DataAccess.Repositories.FilmGenreRepositories;
using Reporting.DataAccess.Repositories.FilmRepositories;
using Reporting.DataAccess.Repositories.GenreRepositories;
using Shared.Exceptions;

namespace Reporting.BusinessLogic.Services.FilmGenreServices
{
    internal class FilmGenreService : IFilmGenreDataCaptureService, IFilmGenreReportingService
    {
        private readonly IFilmGenreRepository _filmGenreRepository;
        private readonly IFilmRepository _filmRepository;
        private readonly IGenreRepository _genreRepository;
        private readonly ILogger<FilmGenreService> _logger;

        public FilmGenreService(IFilmGenreRepository filmGenreRepository, IFilmRepository filmRepository,
            IGenreRepository genreRepository, ILogger<FilmGenreService> logger)
        {
            _filmGenreRepository = filmGenreRepository;
            _filmRepository = filmRepository;
            _genreRepository = genreRepository;
            _logger = logger;
        }

        public async Task CreateAsync(ConsumerFilmGenreDTO filmGenre)
        {
            var existingFilm = await _filmRepository.GetByIdAsync(filmGenre.FilmId);

            if(existingFilm is null)
            {
                _logger.LogError("The film was not found");

                throw new NotFoundException("The film was not found");
            }

            var existingGenre = await _genreRepository.GetByIdAsync(filmGenre.GenreId);

            if(existingGenre is null)
            {
                _logger.LogError("The genre was not found");

                throw new NotFoundException("The genre was not found");
            }

            var mapperModel = filmGenre.Adapt<FilmGenre>();
            _filmGenreRepository.Create(mapperModel);

            await _filmGenreRepository.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid filmId, Guid genreId)
        {
            var existingFilm = await _filmRepository.GetByIdAsync(filmId);

            if(existingFilm is null)
            {
                _logger.LogError("The film was not found");

                throw new NotFoundException("The film was not found");
            }

            var existingGenre = await _genreRepository.GetByIdAsync(genreId);

            if(existingGenre is null)
            {
                _logger.LogError("The genre was not found");

                throw new NotFoundException("The genre was not found");
            }

            _filmGenreRepository.Delete(filmId, genreId);

            await _filmGenreRepository.SaveChangesAsync();
        }
    }
}
