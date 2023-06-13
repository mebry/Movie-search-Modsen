using Rating.BusinessLogic.DTOs;

namespace Rating.BusinessLogic.Services.EventServices
{
    public interface IEventService
    {
        /// <summary>
        /// Checks whether the rating has changed by 0.1 by counting data from the database.
        /// </summary>
        /// <param name="rating">New rating in the database.</param>
        /// <returns>
        ///     true – recalculation required,
        ///     false – recalculation not required
        /// </returns>
        public bool ChangeInAverageRating(RatingDTO rating);
    }
}
