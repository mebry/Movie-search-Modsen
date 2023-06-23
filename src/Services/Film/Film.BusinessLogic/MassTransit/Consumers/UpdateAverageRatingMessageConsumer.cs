using Film.DataAccess.Repositories.Implementations;
using Film.DataAccess.Repositories.Interfaces;
using MassTransit;
using Microsoft.Extensions.Logging;
using Shared.Messages;

namespace Film.BusinessLogic.MassTransit.Consumers
{
    public class UpdateAverageRatingMessageConsumer : IConsumer<UpdateAverageRatingMessage>
    {
        private readonly IFilmRepository _filmRepository;
        private readonly ILogger<UpdateAverageRatingMessageConsumer> _logger;

        public UpdateAverageRatingMessageConsumer(IFilmRepository filmRepository, ILogger<UpdateAverageRatingMessageConsumer> logger)
        {
            _filmRepository = filmRepository;
            _logger = logger;
        }

        public async Task Consume(ConsumeContext<UpdateAverageRatingMessage> context)
        {
            var foundFilm = await _filmRepository.GetByIdAsync(context.Message.FilmId);
            
            foundFilm.AverageRating = context.Message.AverageRating;

            _filmRepository.Update(foundFilm);
            await _filmRepository.SaveChangesAsync();
        }
    }
}
