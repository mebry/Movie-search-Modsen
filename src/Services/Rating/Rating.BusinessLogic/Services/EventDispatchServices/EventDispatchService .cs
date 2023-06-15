using Rating.BusinessLogic.DTOs;

namespace Rating.BusinessLogic.Services.EventDispatchServices
{
    internal class EventDispatchService : IEventDispatchService
    {
        public bool SendNewAverageRating(IEnumerable<FilmDTO> films)
        {
            throw new NotImplementedException();
        }

        public bool SendNewCountOfScores(IEnumerable<FilmDTO> films)
        {
            throw new NotImplementedException();
        }
    }
}
