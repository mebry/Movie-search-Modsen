using Film.DataAccess.Repositories.Interfaces;
using MassTransit;
using Microsoft.Extensions.Logging;
using Shared.Messages.RatingMessages;

namespace Film.BusinessLogic.MassTransit.Consumers.RatingConsumers
{
    /// <summary>
    /// Represents a message consumer for updating the average rating of a film.
    /// </summary>
    public class UpdateAverageRatingMessageConsumer : IConsumer<UpdateAverageRatingMessage>
    {
        private readonly IFilmRepository _filmRepository;
        private readonly ILogger<UpdateAverageRatingMessageConsumer> _logger;

        public UpdateAverageRatingMessageConsumer(IFilmRepository filmRepository,
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
        public async Task Consume(ConsumeContext<UpdateAverageRatingMessage> context)
        {
            var foundFilm = await _filmRepository.GetByIdAsync(context.Message.FilmId);

            double previousAverageRating = foundFilm.AverageRating;
            foundFilm.AverageRating = context.Message.AverageRating;

            _filmRepository.Update(foundFilm);
            await _filmRepository.SaveChangesAsync();

            _logger.LogInformation($"The film with Id: {foundFilm.Id} has had its average rating successfully updated." +
                $" The previous rating was {previousAverageRating}," +
                $" and the new rating is {context.Message.AverageRating}.");
        }
    }
}
