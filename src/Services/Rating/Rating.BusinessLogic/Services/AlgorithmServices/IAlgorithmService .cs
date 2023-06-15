using Rating.DataAccess.Entities;

namespace Rating.BusinessLogic.Services.AlgorithmServices
{
    internal interface IAlgorithmService
    {
        public bool IsTherePossibilityToChangeAverageRating(double oldAverageRating, int oldCountOfScores, int newScore, int newCountOfScores);
        public bool CountOfScoresСhangesInSpecifiedPercentage(Film film);
        public bool CountOfScoresForLongPeriod(Film film);
    }
}
