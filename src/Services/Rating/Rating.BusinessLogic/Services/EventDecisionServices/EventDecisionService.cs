using Mapster;
using Microsoft.Extensions.Logging;
using Rating.BusinessLogic.DTOs;
using Rating.BusinessLogic.Services.AlgorithmServices;
using Rating.BusinessLogic.Services.EventDispatchServices;
using Rating.DataAccess.Entities;
using Rating.DataAccess.Repositories.FilmRepositories;
using Rating.DataAccess.Repositories.RaitingRepositories;
using Shared.Exceptions;

namespace Rating.BusinessLogic.Services.EventDecisionServices
{
    internal class EventDecisionService : IEventDecisionService
    {
        private readonly IEventDispatchService _eventDispatchService;
        private readonly IAlgorithmsForEventDecisionService _algorithmService;
        private readonly IFilmRepository _filmRepository;
        private readonly IRatingFilmRepository _ratingRepository;
        private readonly ILogger<EventDecisionService> _logger;

        public EventDecisionService(IEventDispatchService eventDispatchService, IAlgorithmsForEventDecisionService algorithmService,
            IFilmRepository filmRepository, IRatingFilmRepository ratingRepository, ILogger<EventDecisionService> logger)
        {
            _eventDispatchService = eventDispatchService;
            _algorithmService = algorithmService;
            _filmRepository = filmRepository;
            _ratingRepository = ratingRepository;
            _logger = logger;
        }

        public async Task<bool> DecisionToSendAveragRatingChangEventAsync(RequestRatingDTO rating, int change)
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
                return false;

            var averageRating = await _ratingRepository.CalculateAverageRatingByFilmId(rating.FilmId);

            oldAverageRating = existingFilm.AverageRating;
            existingFilm.AverageRating = averageRating;

            _filmRepository.Update(existingFilm);

            if(averageRating < oldAverageRating + 0.1)
                return false;

            var filmDto = existingFilm.Adapt<FilmDTO>();
            await _eventDispatchService.SendNewAverageRatingAsync(filmDto);

            return true;
        }

        public async Task<bool> DecisionToSendCountOfScoresLongChangEventAsync()
        {
            var predicate = _algorithmService.CountOfScoresForLongPeriod;

            return await DecisionToSendCountOfScoresChangEventAsync(predicate);
        }

        public async Task<bool> DecisionToSendCountOfScoresShortChangEventAsync()
        {
            var predicate = _algorithmService.CountOfScoresСhangesInSpecifiedPercentage;

            return await DecisionToSendCountOfScoresChangEventAsync(predicate);
        }

        private async Task<bool> DecisionToSendCountOfScoresChangEventAsync(Func<Film, bool> func)
        {

            var films = _filmRepository.GetAllByPredicate(func);

            if(films is null || films.Count() == 0)
                return false;

            var eventFilms = await PreparingToSendCountOfScoresAsync(films);

            await _eventDispatchService.SendNewCountOfScoresAsync(eventFilms);

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
