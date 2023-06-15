using Rating.BusinessLogic.DTOs;

namespace Rating.BusinessLogic.Services.EventDispatchServices
{
    public interface IEventDispatchService
    {
        // TODO: тут будут другие входные параметры
        public bool SendNewAverageRating(IEnumerable<FilmDTO> films);
        public bool SendNewCountOfScores(IEnumerable<FilmDTO> films);
    }
}
