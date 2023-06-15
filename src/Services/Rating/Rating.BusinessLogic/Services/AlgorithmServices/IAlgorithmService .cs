using Rating.BusinessLogic.DTOs;
using Rating.DataAccess.Entities;

namespace Rating.BusinessLogic.Services.AlgorithmServices
{
    internal interface IAlgorithmService
    {
        public bool IsTherePossibilityToChangeAverageRating(RequestRatingDTO rating, FilmDTO film);
        public bool CountOfScoresСhangesInSpecifiedPercentage(Film film);
        public bool CountOfScoresForLongPeriod(Film film);
    }
}
