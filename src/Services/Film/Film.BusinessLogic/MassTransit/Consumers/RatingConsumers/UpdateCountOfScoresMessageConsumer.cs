using Film.DataAccess.Repositories.Interfaces;
using MassTransit;
using Microsoft.Extensions.Logging;
using Shared.Messages.RatingMessages;

namespace Film.BusinessLogic.MassTransit.Consumers.RatingConsumers
{
    /// <summary>
    /// Represents a message consumer for updating the count of scores for a film.
    /// </summary>
    public class UpdateCountOfScoresMessageConsumer : IConsumer<UpdateCountOfScoresMessage>
    {
        private readonly IFilmRepository _filmRepository;
        private readonly ILogger<UpdateAverageRatingMessageConsumer> _logger;

        public UpdateCountOfScoresMessageConsumer(IFilmRepository filmRepository,
            ILogger<UpdateAverageRatingMessageConsumer> logger)
        {
            _filmRepository = filmRepository;
            _logger = logger;
        }

        /// <summary>
        /// Consumes the specified message.
        /// </summary>
        /// <param name="context">The message context.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task Consume(ConsumeContext<UpdateCountOfScoresMessage> context)
        {
            var foundFilm = await _filmRepository.GetByIdAsync(context.Message.FilmId);

            int previousCountScores = foundFilm.CountScores;
            foundFilm.CountScores = context.Message.CountOfScores;

            _filmRepository.Update(foundFilm);
            await _filmRepository.SaveChangesAsync();

            _logger.LogInformation($"The film with Id: {foundFilm.Id} has had its count of scores successfully updated." +
                $" The previous count of scores was {previousCountScores}, " +
                $"and the new count of scores is {context.Message.CountOfScores}.");
        }
    }
}
