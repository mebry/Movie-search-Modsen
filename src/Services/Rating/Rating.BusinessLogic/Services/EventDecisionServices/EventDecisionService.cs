using Mapster;
using Rating.BusinessLogic.DTOs;
using Rating.BusinessLogic.Services.AlgorithmServices;
using Rating.BusinessLogic.Services.EventDispatchServices;
using Rating.DataAccess.Entities;
using Rating.DataAccess.Repositories.FilmRepositories;

namespace Rating.BusinessLogic.Services.EventDecisionServices
{
    internal class EventDecisionService : IEventDecisionService
    {
        private readonly IEventDispatchService _eventDispatchService;
        private readonly IAlgorithmService _algorithmService;
        private readonly IFilmRepository _filmRepository;

        public EventDecisionService(IEventDispatchService eventDispatchService, IAlgorithmService algorithmService, IFilmRepository filmRepository)
        {
            _eventDispatchService = eventDispatchService;
            _algorithmService = algorithmService;
            _filmRepository = filmRepository;
        }

        public Task<bool> DecisionToSendAveragRatingChangEventAsync(RequestRatingDTO rating)
        {
            throw new NotImplementedException();
        }

        public async Task DecisionToSendCountOfScoresLongChangEventAsync()
        {
            var predicate = _algorithmService.CountOfScoresForLongPeriod;

            await DecisionToSendCountOfScoresChangEventAsync(predicate);
        }

        public async Task DecisionToSendCountOfScoresShortChangEventAsync()
        {
            var predicate = _algorithmService.CountOfScoresСhangesInSpecifiedPercentage;

            await DecisionToSendCountOfScoresChangEventAsync(predicate);
        }

        private async Task DecisionToSendCountOfScoresChangEventAsync(Func<Film, bool> predicate)
        {
            var films = await _filmRepository.GetAllByPredicate(predicate);

            if(films.Count() == 0)
                return;

            var eventFilms = await PreparingToSendCountOfScoresAsync(films);

            _eventDispatchService.SendNewCountOfScores(eventFilms);
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
