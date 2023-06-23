using FluentValidation;
using FluentValidation.Results;
using Mapster;
using Microsoft.Extensions.Logging;
using Rating.BusinessLogic.DTOs;
using Rating.BusinessLogic.Enums;
using Rating.BusinessLogic.Extensions;
using Rating.BusinessLogic.Services.EventDecisionServices;
using Rating.DataAccess.Entities;
using Rating.DataAccess.Repositories.FilmRepositories;
using Rating.DataAccess.Repositories.RaitingRepositories;
using Shared.Exceptions;

namespace Rating.BusinessLogic.Services.RatingServices
{
    internal class RatingService : IRatingService
    {
        private readonly IFilmRepository _filmRepository;
        private readonly IRatingFilmRepository _ratingRepository;
        private readonly ILogger<RatingService> _logger;
        private readonly IValidator<RequestRatingDTO> _validator;
        private readonly IEventDecisionService _eventDecisionService;

        public RatingService(IFilmRepository filmRepository, IRatingFilmRepository ratingRepository,
            ILogger<RatingService> logger, IValidator<RequestRatingDTO> validator, IEventDecisionService eventDecisionService)
        {
            _filmRepository = filmRepository;
            _ratingRepository = ratingRepository;
            _logger = logger;
            _validator = validator;
            _eventDecisionService = eventDecisionService;
        }

        public async Task<ResponseRatingDTO> CreateAsync(RequestRatingDTO model)
        {
            ValidationResult result = await _validator.ValidateAsync(model);

            if(!result.IsValid)
            {
                var errorMessages = result.ResultErrorMessage();

                throw new ValidationProblemException(errorMessages);
            }

            var exists = await _ratingRepository.IsThereUserIdForFilmIdAsync(model.FilmId, model.UserId);

            if(exists)
            {
                _logger.LogError("The user has already rated this film");

                throw new AlreadyExistsException("The user has already rated this film");
            }

            var mapperModel = model.Adapt<RatingFilm>();
            mapperModel.Id = Guid.NewGuid();

            _ratingRepository.Create(mapperModel);

            var film = await _eventDecisionService
                .DecisionToSendAverageRatingChangeEventAsync(model, (int)Changes.Create);

            film.CountOfScores++;

            _filmRepository.Update(film);

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

            var requestRatingDto = existingRating.Adapt<RequestRatingDTO>();

            var film = await _eventDecisionService.DecisionToSendAverageRatingChangeEventAsync(requestRatingDto, (int)Changes.Delete);

            film.CountOfScores--;

            _filmRepository.Update(film);

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

            var film = await _eventDecisionService.DecisionToSendAverageRatingChangeEventAsync(model, (int)Changes.Update);

            _ratingRepository.Update(mapperModel);
            _filmRepository.Update(film);

            await _ratingRepository.SaveAsync();

            var responseModel = mapperModel.Adapt<ResponseRatingDTO>();

            return responseModel;
        }
    }
}
