using Rating.BusinessLogic.DTOs;

namespace Rating.BusinessLogic.Services.EventDecisionServices
{
    public interface IEventDecisionService
    {
        /// <summary>
        /// This method makes a decision on sending an event from EventDispatchService.
        /// </summary>
        /// <param name="rating"></param>
        /// <returns></returns>
        public Task<bool> DecisionToSendAveragRatingChangEventAsync(RequestRatingDTO rating, int change)

        /// <summary>
        /// The service decides whether to send an event for changes to CountOfScore. This method checks for changes every few hours.
        /// </summary>
        /// <param name="rating"></param>
        /// <returns></returns>
        public Task<bool> DecisionToSendCountOfScoresShortChangEventAsync();

        /// <summary>
        /// The service decides whether to send an event for changes to CountOfScore. This method checks for changes every month.
        /// </summary>
        /// <param name="rating"></param>
        /// <returns></returns>
        public Task<bool> DecisionToSendCountOfScoresLongChangEventAsync();
    }
}
