﻿using Mapster;
using Microsoft.Extensions.Logging;
using Reporting.BusinessLogic.DTOs.ConsumerDTOs;
using Reporting.BusinessLogic.DTOs.ResponseDTOs;
using Reporting.DataAccess.Entities;
using Reporting.DataAccess.Repositories.FilmRepositories;
using Reporting.DataAccess.Repositories.RatingRepositories;
using Shared.Exceptions;

namespace Reporting.BusinessLogic.Services.FilmServices
{
    internal class FilmService : IFilmDataCaptureService, IFilmReportingService
    {
        private readonly IFilmRepository _filmRepository;
        private readonly IRatingRepository _ratingRepository;
        private readonly ILogger<FilmService> _logger;

        public FilmService(IFilmRepository filmRepository, IRatingRepository ratingRepository, ILogger<FilmService> logger)
        {
            _filmRepository = filmRepository;
            _ratingRepository = ratingRepository;
            _logger = logger;
        }

        public async Task CreateAsync(ConsumerFilmDTO entity)
        {
            var mapperModel = entity.Adapt<Film>();
            _filmRepository.Create(mapperModel);

            await _filmRepository.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var existingFilm = await _filmRepository.GetByIdAsync(id);

            if(existingFilm is null)
            {
                _logger.LogError("The film was not found");

                throw new NotFoundException("The film was not found");
            }

            _filmRepository.Delete(id);

            await _filmRepository.SaveChangesAsync();
        }

        public async Task UpdateAsync(ConsumerFilmDTO entity)
        {
            var existingFilm = await _filmRepository.GetByIdAsync(entity.Id);

            if(existingFilm is null)
            {
                _logger.LogError("The film was not found");

                throw new NotFoundException("The film was not found");
            }

            await UpdateFilmAsync(entity, existingFilm);
        }

        public async Task UpdateAverageRatingAsync(ConsumerAverageRatingDTO entity)
        {
            var existingFilm = await _filmRepository.GetByIdAsync(entity.FilmId);

            if(existingFilm is null)
            {
                _logger.LogError("The film was not found");

                throw new NotFoundException("The film was not found");
            }

            await UpdateFilmAsync(entity, existingFilm);
        }

        public async Task UpdateCountOfScoresAsync(ConsumerCountOfScoresDTO entity)
        {
            var existingFilm = await _filmRepository.GetByIdAsync(entity.FilmId);

            if(existingFilm is null)
            {
                _logger.LogError("The film was not found");

                throw new NotFoundException("The film was not found");
            }

            await UpdateFilmAsync(entity, existingFilm);
        }

        private async Task UpdateFilmAsync<T>(T entity, Film existingFilm)
        {
            entity.Adapt(existingFilm);
            _filmRepository.Update(existingFilm);

            await _filmRepository.SaveChangesAsync();
        }
    }
}
