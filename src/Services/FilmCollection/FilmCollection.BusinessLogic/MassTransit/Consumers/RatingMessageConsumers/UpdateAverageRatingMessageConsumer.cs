using FilmCollection.DataAccess.Repositories.Interfaces;
using MassTransit;
using Microsoft.Extensions.Logging;
using Shared.Messages.RatingMessages;

namespace FilmCollection.BusinessLogic.MassTransit.Consumers.RatingMessageConsumers
{
    public class UpdateAverageRatingMessageConsumer : IConsumer<UpdateAverageRatingMessage>
    {
        private readonly IBaseFilmInfoRepository _baseFilmInfoRepository;
        private readonly ILogger<UpdateAverageRatingMessageConsumer> _logger;

        public UpdateAverageRatingMessageConsumer(IBaseFilmInfoRepository baseFilmInfoRepository, ILogger<UpdateAverageRatingMessageConsumer> logger)
        {
            _baseFilmInfoRepository = baseFilmInfoRepository;
            _logger = logger;
        }

        public async Task Consume(ConsumeContext<UpdateAverageRatingMessage> context)
        {
            var filmInfoToUpdate = await _baseFilmInfoRepository.GetBaseFilmInfoByIdAsync(context.Message.FilmId, true);

            var oldValue = filmInfoToUpdate.AverageRating;

            filmInfoToUpdate.AverageRating = context.Message.AverageRating;

            await _baseFilmInfoRepository.UpdateBaseFilmInfoAsync(filmInfoToUpdate);
            
            
            _logger.LogInformation($"Average rating in the base film info with {filmInfoToUpdate.Id} id was successfully updated." +
                $"Old value was {oldValue} now its {filmInfoToUpdate.AverageRating}");
        }
    }
}
