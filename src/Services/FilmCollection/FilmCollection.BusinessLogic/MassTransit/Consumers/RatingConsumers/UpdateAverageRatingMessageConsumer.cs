using FilmCollection.DataAccess.Repositories.Interfaces;
using MassTransit;
using Shared.Messages.RatingMessages;

namespace FilmCollection.BusinessLogic.MassTransit.Consumers.RatingConsumers
{
    public class UpdateAverageRatingMessageConsumer : IConsumer<UpdateAverageRatingMessage>
    {
        private readonly IBaseFilmInfoRepository _baseFilmInfoRepository;

        public UpdateAverageRatingMessageConsumer(IBaseFilmInfoRepository baseFilmInfoRepository)
        {
            _baseFilmInfoRepository = baseFilmInfoRepository;
        }

        public async Task Consume(ConsumeContext<UpdateAverageRatingMessage> context)
        {
            var filmInfoToUpdate = await _baseFilmInfoRepository.GetBaseFilmInfoByIdAsync(context.Message.FilmId, true);

            filmInfoToUpdate.AverageRating = context.Message.AverageRating;

            await _baseFilmInfoRepository.UpdateBaseFilmInfoAsync(filmInfoToUpdate);
        }
    }
}
