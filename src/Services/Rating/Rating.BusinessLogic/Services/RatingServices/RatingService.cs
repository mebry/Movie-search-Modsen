using FluentValidation;
using FluentValidation.Results;
using Mapster;
using Microsoft.Extensions.Logging;
using Rating.BusinessLogic.DTOs;
using Rating.BusinessLogic.Exceptions;
using Rating.BusinessLogic.Extensions;
using Rating.DataAccess.Entities;
using Rating.DataAccess.Repositories.RaitingRepositories;

namespace Rating.BusinessLogic.Services.RatingServices
{
    internal class RatingService : IRatingService
    {
        private readonly IRatingFilmRepository _ratingRepository;
        private readonly ILogger<RatingService> _logger;
        private IValidator<RatingFilm> _validator;

        public RatingService(IRatingFilmRepository ratingRepository, ILogger<RatingService> logger, IValidator<RatingFilm> validator)
        {
            _ratingRepository = ratingRepository;
            _logger = logger;
            _validator = validator;
        }

        public async Task<RatingDTO> CreateAsync(RatingDTO model)
        {
            var ratingChecked = await _ratingRepository.GetByIdAsync(model.Id);

            if(ratingChecked is not null)
            {
                _logger.LogError("The creation attempt failed. This id is already in use");

                throw new AlreadyExistException("This id is already used");
            }

            var mapperModel = model.Adapt<RatingFilm>();

            ValidationResult result = await _validator.ValidateAsync(mapperModel);

            if(!result.IsValid)
            {
                var errorMessages = result.ResultErrorMessage();

                throw new ValidationProblem(errorMessages);
            }

            _ratingRepository.Create(mapperModel);

            await _ratingRepository.SaveAsync();

            return model;
        }

        public async Task<RatingDTO> DeleteAsync(RatingDTO model)
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

        public async Task<RatingDTO> UpdateAsync(RatingDTO model)
        {
            var ratingChecked = await _ratingRepository.GetByIdAsync(model.Id);

            if(ratingChecked is null)
            {
                _logger.LogError("The deletion attempt failed. This id is missing");

                throw new NotFoundException("This id is missing");
            }

            var mapperModel = model.Adapt<RatingFilm>();

            _ratingRepository.Update(mapperModel);

            await _ratingRepository.SaveAsync();

            return model;
        }
    }
}
