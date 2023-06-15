﻿using FluentValidation;
using FluentValidation.Results;
using Mapster;
using Microsoft.Extensions.Logging;
using Rating.BusinessLogic.DTOs;
using Rating.BusinessLogic.Exceptions;
using Rating.BusinessLogic.Extensions;
using Rating.BusinessLogic.Services.FilmServices;
using Rating.DataAccess.Entities;
using Rating.DataAccess.Repositories.RaitingRepositories;

namespace Rating.BusinessLogic.Services.RatingServices
{
    internal class RatingService : IRatingService
    {
        private readonly IFilmService _filmService;
        private readonly IRatingFilmRepository _ratingRepository;
        private readonly ILogger<RatingService> _logger;
        private readonly IValidator<RatingFilm> _validator;

        public RatingService(IFilmService filmService, IRatingFilmRepository ratingRepository, ILogger<RatingService> logger, IValidator<RatingFilm> validator)
        {
            _filmService = filmService;
            _ratingRepository = ratingRepository;
            _logger = logger;
            _validator = validator;
        }

        public async Task<ResponseRatingDTO> CreateAsync(RequestRatingDTO model)
        {
            var mapperModel = model.Adapt<RatingFilm>();

            mapperModel.Id = Guid.NewGuid();

            ValidationResult result = await _validator.ValidateAsync(mapperModel);

            if(!result.IsValid)
            {
                var errorMessages = result.ResultErrorMessage();

                throw new ValidationProblemException(errorMessages);
            }

            _ratingRepository.Create(mapperModel);

            await _filmService.IncrementCountOfScores((Guid)mapperModel.FilmId!);

            await _ratingRepository.SaveAsync();

            var responseModel = mapperModel.Adapt<ResponseRatingDTO>();

            return responseModel;
        }

        public async Task<ResponseRatingDTO> DeleteAsync(Guid id)
        {
            var existingRating = await _ratingRepository.GetByIdAsync(id);

            if(existingRating is null)
            {
                _logger.LogError("The deletion attempt failed. This id is missing");

                throw new NotFoundException("This id is missing");
            }

            _ratingRepository.Delete(existingRating);

            await _filmService.DecrementCountOfScores((Guid)existingRating.FilmId!);

            await _ratingRepository.SaveAsync();

            var responseModel = existingRating.Adapt<ResponseRatingDTO>();

            return responseModel;
        }

        public async Task<ResponseRatingDTO?> GetByIdAsync(Guid id)
        {
            var filmChecked = await _ratingRepository.GetByIdAsync(id);

            if(filmChecked is null)
            {
                _logger.LogError("The deletion attempt failed. This id is missing");

                throw new NotFoundException("This id is missing");
            }

            var mappingModel = filmChecked.Adapt<ResponseRatingDTO>();

            return mappingModel;
        }

        public async Task<ResponseRatingDTO> UpdateAsync(Guid id, RequestRatingDTO model)
        {
            var existingRating = await _ratingRepository.GetByIdAsync(id);

            if(existingRating is null)
            {
                _logger.LogError("The deletion attempt failed. This id is missing");

                throw new NotFoundException("This id is missing");
            }

            var mapperModel = model.Adapt<RatingFilm>();

            mapperModel.Id = id;

            _ratingRepository.Update(mapperModel);

            await _ratingRepository.SaveAsync();

            var responseModel = mapperModel.Adapt<ResponseRatingDTO>();

            return responseModel;
        }
    }
}
