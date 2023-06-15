using Rating.DataAccess.Entities;

namespace Rating.BusinessLogic.Services.AlgorithmServices
{
    internal class AlgorithmsForEventDecisionService : IAlgorithmsForEventDecisionService
    {
        const double Precentage = 10;

        public bool CountOfScoresForLongPeriod(Film film)
            => film.CountOfScores > film.OldCountOfScores;

        public bool CountOfScoresСhangesInSpecifiedPercentage(Film film)
            => ((film.CountOfScores / film.OldCountOfScores) * 100 - 100) > Precentage;

        public bool IsTherePossibilityToChangeAverageRating(double oldAverageRating, uint oldCountOfScores, int newScore, uint newCountOfScores)
        {
            double oldTotalRating = oldAverageRating * oldCountOfScores;
            double newTotalRating = oldTotalRating + newScore;

            double newAverageRating = newTotalRating / newCountOfScores;

            double ratingDifference = Math.Abs(newAverageRating - oldAverageRating);

            return ratingDifference >= 0.1;
        }
    }
}
