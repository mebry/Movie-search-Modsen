﻿using Mapster;
using Microsoft.Extensions.Logging;
using Reporting.BusinessLogic.DTOs.ConsumerDTOs;
using Reporting.DataAccess.Entities;
using Reporting.DataAccess.Repositories.GenreRepositories;
using Shared.Exceptions;

namespace Reporting.BusinessLogic.Services.GenreServices
{
    internal class GenreService : IGenreDataCaptureService, IGenreReportingService
    {
        private readonly IGenreRepository _genreRepository;
        private readonly ILogger<GenreService> _logger;

        public GenreService(IGenreRepository genreRepository, ILogger<GenreService> logger)
        {
            _genreRepository = genreRepository;
            _logger = logger;
        }

        public async Task CreateAsync(ConsumerGenreDTO entity)
        {
            var mapperModel = entity.Adapt<Genre>();
            _genreRepository.Create(mapperModel);

            await _genreRepository.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var existingGenre = await _genreRepository.GetByIdAsync(id);

            if(existingGenre is null)
            {
                _logger.LogError("The genre was not found");

                throw new NotFoundException("The genre was not found");
            }

            _genreRepository.Delete(id);

            await _genreRepository.SaveChangesAsync();
        }

        public async Task UpdateAsync(ConsumerGenreDTO entity)
        {
            var existingGenre = await _genreRepository.GetByIdAsync(entity.Id);

            if(existingGenre is null)
            {
                _logger.LogError("The genre was not found");

                throw new NotFoundException("The genre was not found");
            }

            entity.Adapt(existingGenre);
            _genreRepository.Update(existingGenre);

            await _genreRepository.SaveChangesAsync();
        }
    }
}
