using Rating.BusinessLogic.DTOs;

namespace Rating.BusinessLogic.Services.EventDispatchServices
{
    public interface IEventDispatchService
    {
        public Task SendNewAverageRatingAsync(FilmDTO film);
        public Task SendNewCountOfScoresAsync(IEnumerable<FilmDTO> film);
    }
}
