using FluentValidation;
using Mapster;
using MassTransit;
using Microsoft.Extensions.Logging;
using Rating.BusinessLogic.DTOs;
using Rating.BusinessLogic.Enums;
using Rating.BusinessLogic.Extensions;
using Rating.BusinessLogic.Services.EventDecisionServices;
using Rating.DataAccess.Entities;
using Rating.DataAccess.Repositories.FilmRepositories;
using Rating.DataAccess.Repositories.RaitingRepositories;
using Shared.Exceptions;
using Shared.Messages.RatingMessages;

namespace Rating.BusinessLogic.Services.RatingServices
{
    internal class RatingService : IRatingService
    {
        private readonly IFilmRepository _filmRepository;
        private readonly IRatingFilmRepository _ratingRepository;
        private readonly ILogger<RatingService> _logger;
        private readonly IValidator<RequestRatingDTO> _validator;
        private readonly IEventDecisionService _eventDecisionService;
        private readonly IPublishEndpoint _publishEndpoint;

        public RatingService(IFilmRepository filmRepository, IRatingFilmRepository ratingRepository,
            ILogger<RatingService> logger, IValidator<RequestRatingDTO> validator,
            IEventDecisionService eventDecisionService, IPublishEndpoint publishEndpoint)
        {
            _filmRepository = filmRepository;
            _ratingRepository = ratingRepository;
            _logger = logger;
            _validator = validator;
            _eventDecisionService = eventDecisionService;
            _publishEndpoint = publishEndpoint;
        }

        public async Task<ResponseRatingDTO> CreateAsync(RequestRatingDTO model)
        {
            var result = await _validator.ValidateAsync(model);

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

            await UpdateFilmWhenRatingIsCreated(model);

            var message = mapperModel.Adapt<CreateRatingMessage>();

            await _publishEndpoint.Publish(message);

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

            await UpdateFilmWhenRatingIsDeleted(requestRatingDto);

            var message = existingRating.Adapt<DeleteRatingMessage>();

            await _publishEndpoint.Publish(message);

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
                _logger.LogError("The updation attempt failed. This id is missing");

                throw new NotFoundException("This id is missing");
            }

            var mapperModel = model.Adapt<RatingFilm>();
            mapperModel.Id = id;

            _ratingRepository.Update(mapperModel);

            await UpdateFilmWhenRatingIsUpdated(model);

            var message = existingRating.Adapt<UpdateRatingMessage>();

            await _publishEndpoint.Publish(message);

            await _ratingRepository.SaveAsync();

            var responseModel = mapperModel.Adapt<ResponseRatingDTO>();

            return responseModel;
        }

        private async Task UpdateFilmWhenRatingIsUpdated(RequestRatingDTO ratingDTO)
        {
            var film = await _eventDecisionService.DecisionToSendAverageRatingChangeEventAsync(ratingDTO, (int)CountOfScoresChanges.Update);

            _filmRepository.Update(film);
        }

        private async Task UpdateFilmWhenRatingIsCreated(RequestRatingDTO ratingDTO)
        {
            var film = await _eventDecisionService.DecisionToSendAverageRatingChangeEventAsync(ratingDTO, (int)CountOfScoresChanges.Create);

            film.CountOfScores++;

            _filmRepository.Update(film);
        }

        private async Task UpdateFilmWhenRatingIsDeleted(RequestRatingDTO ratingDTO)
        {
            var film = await _eventDecisionService.DecisionToSendAverageRatingChangeEventAsync(ratingDTO, (int)CountOfScoresChanges.Delete);

            film.CountOfScores--;

            _filmRepository.Update(film);
        }
    }
}
