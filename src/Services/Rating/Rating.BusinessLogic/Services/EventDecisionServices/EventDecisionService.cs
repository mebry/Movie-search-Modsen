using Mapster;
using MassTransit;
using Microsoft.Extensions.Logging;
using Rating.BusinessLogic.DTOs;
using Rating.BusinessLogic.Services.AlgorithmServices;
using Rating.DataAccess.Entities;
using Rating.DataAccess.Repositories.FilmRepositories;
using Rating.DataAccess.Repositories.RaitingRepositories;
using Shared.Exceptions;
using Shared.Messages;
using System.Collections.Generic;

namespace Rating.BusinessLogic.Services.EventDecisionServices
{
    internal class EventDecisionService : IEventDecisionService
    {
        private readonly IAlgorithmsForEventDecisionService _algorithmService;
        private readonly IFilmRepository _filmRepository;
        private readonly IRatingFilmRepository _ratingRepository;
        private readonly IPublishEndpoint _publishEndpoint;
        private readonly ILogger<EventDecisionService> _logger;

        public EventDecisionService(IAlgorithmsForEventDecisionService algorithmService,
            IFilmRepository filmRepository, IPublishEndpoint publishEndpoint, IRatingFilmRepository ratingRepository, ILogger<EventDecisionService> logger)
        {
            _algorithmService = algorithmService;
            _filmRepository = filmRepository;
            _ratingRepository = ratingRepository;
            _publishEndpoint = publishEndpoint;
            _logger = logger;
        }

        public async Task<Film> DecisionToSendAverageRatingChangeEventAsync(RequestRatingDTO rating, int change)
        {
            var existingFilm = await _filmRepository.GetByIdAsync(rating.FilmId);

            if(existingFilm is null)
            {
                _logger.LogError("The decrement attempt failed. This id is missing");

                throw new NotFoundException("This id is missing");
            }

            double oldAverageRating = existingFilm.AverageRating;
            int newScore = rating.Score;
            uint oldCountOfScores = existingFilm.CountOfScores;
            uint newCountOfScores = (uint)(existingFilm.CountOfScores + change);

            var isPosible = _algorithmService.IsTherePossibilityToChangeAverageRating(oldAverageRating, oldCountOfScores, newScore, newCountOfScores);

            if(!isPosible)
                return existingFilm;

            await CalculateNewAverageRatingAsync(existingFilm, newScore);

            var message = existingFilm.Adapt<UpdateAverageRatingMessage>();

            await _publishEndpoint.Publish(message);

            return existingFilm;
        }

        private async Task CalculateNewAverageRatingAsync(Film film, int score)
        {
            if(film.CountOfScores != 0)
            {
                double averageRating = await _ratingRepository.CalculateAverageRatingByFilmIdAsync(film.Id);

                film.AverageRating = averageRating;
            }
            else
                film.AverageRating = score;
        }

        public async Task<bool> DecisionToSendCountOfScoresLongChangeEventAsync()
        {
            var predicate = _algorithmService.CountOfScoresForLongPeriod;

            return await DecisionToSendCountOfScoresChangeEventAsync(predicate);
        }

        public async Task<bool> DecisionToSendCountOfScoresShortChangeEventAsync()
        {
            var predicate = _algorithmService.CountOfScoresСhangesInSpecifiedPercentage;

            return await DecisionToSendCountOfScoresChangeEventAsync(predicate);
        }

        private async Task<bool> DecisionToSendCountOfScoresChangeEventAsync(Func<Film, bool> func)
        {

            var films = _filmRepository.GetAllByPredicate(func);

            if(films is null || films.Count() == 0)
                return false;

            var eventFilms = await PreparingToSendCountOfScoresAsync(films);

            var message = eventFilms.Adapt<IEnumerable<UpdateCountOfScoresMessage>>();

            await _publishEndpoint.Publish(message);

            return true;
        }

        private async Task<IEnumerable<FilmDTO>> PreparingToSendCountOfScoresAsync(IEnumerable<Film> films)
        {
            films.ToList().ForEach(film =>
            {
                film.OldCountOfScores = film.CountOfScores;
                _filmRepository.Update(film);
            });

            await _filmRepository.SaveAsync();

            var eventFilms = films.Adapt<IEnumerable<FilmDTO>>();

            return eventFilms;
        }
    }
}
