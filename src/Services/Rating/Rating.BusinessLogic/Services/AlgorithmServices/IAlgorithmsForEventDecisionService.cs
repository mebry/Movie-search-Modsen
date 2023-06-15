using Rating.DataAccess.Entities;

namespace Rating.BusinessLogic.Services.AlgorithmServices
{
    internal interface IAlgorithmsForEventDecisionService
    {
        public bool IsTherePossibilityToChangeAverageRating(double oldAverageRating, uint oldCountOfScores, int newScore, uint newCountOfScores);
        public bool CountOfScoresСhangesInSpecifiedPercentage(Film film);
        public bool CountOfScoresForLongPeriod(Film film);
    }
}
