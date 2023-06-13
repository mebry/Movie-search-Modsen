using Mapster;
using Microsoft.Extensions.Logging;
using Rating.BusinessLogic.DTOs;
using Rating.BusinessLogic.Exceptions;
using Rating.DataAccess.Entities;
using Rating.DataAccess.Repositories.RaitingRepositories;

namespace Rating.BusinessLogic.Services.RatingServices
{
    internal class RatingService : IRatingService
    {
        private readonly IRatingFilmRepository _ratingRepository;
        private readonly ILogger<RatingService> _logger;

        public RatingService(IRatingFilmRepository ratingRepository, ILogger<RatingService> logger)
        {
            _ratingRepository = ratingRepository;
            _logger = logger;
        }

        public async Task<RatingDTO> Create(RatingDTO model)
        {
            var ratingChecked = await _ratingRepository.GetByIdAsync(model.Id);

            if(ratingChecked is not null)
            {
                _logger.LogError("The creation attempt failed. This id is already in use");

                throw new NotFoundException("This id is already used");
            }

            var mapperModel = model.Adapt<RatingFilm>();

            _ratingRepository.Create(mapperModel);

            await _ratingRepository.SaveAsync();

            return model;
        }

        public async Task<RatingDTO> Delete(RatingDTO model)
        {
            var ratingChecked = await _ratingRepository.GetByIdAsync(model.Id);

            if(ratingChecked is null)
            {
                _logger.LogError("The deletion attempt failed. This id is missing");

                throw new NotFoundException("This id is missing");
            }

            _ratingRepository.Delete(ratingChecked);

            await _ratingRepository.SaveAsync();

            return model;
        }

        public async Task<RatingDTO?> GetByIdAsync(Guid id)
        {
            var filmChecked = await _ratingRepository.GetByIdAsync(id);

            if(filmChecked is null)
            {
                _logger.LogError("The deletion attempt failed. This id is missing");

                throw new NotFoundException("This id is missing");
            }

            var mappingModel = filmChecked.Adapt<RatingDTO>();

            return mappingModel;
        }

        public async Task<RatingDTO> Update(RatingDTO model)
        {
            var ratingChecked = await _ratingRepository.GetByIdAsync(model.Id);

            if(ratingChecked is null)
            {
                _logger.LogError("The deletion attempt failed. This id is missing");

                throw new NotFoundException("This id is missing");
            }

            _ratingRepository.Update(ratingChecked);

            await _ratingRepository.SaveAsync();

            return model;
        }
    }
}
