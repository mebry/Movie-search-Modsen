using Rating.BusinessLogic.DTOs;
using Rating.DataAccess.Entities;

namespace Rating.BusinessLogic.Services.AlgorithmServices
{
    internal class AlgorithmService : IAlgorithmService
    {
        const double Precentage = 10;

        public bool CountOfScoresForLongPeriod(Film film)
            => film.CountOfScores > film.OldCountOfScores;

        public bool CountOfScoresСhangesInSpecifiedPercentage(Film film)
            => ((film.OldCountOfScores / film.CountOfScores) * 100 - 100) > Precentage;
        public bool IsTherePossibilityToChangeAverageRating(RequestRatingDTO rating, FilmDTO film)
        {
            throw new NotImplementedException();
        }
    }
}
