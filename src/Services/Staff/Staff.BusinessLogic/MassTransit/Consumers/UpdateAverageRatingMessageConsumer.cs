using Mapster;
using MassTransit;
using Microsoft.Extensions.Logging;
using Shared.Messages.RatingMessages;
using Staff.BusinessLogic.DTOs;
using Staff.BusinessLogic.Services.Interfaces;

namespace Staff.BusinessLogic.MassTransit.Consumers
{
    public class UpdateAverageRatingMessageConsumer : IConsumer<UpdateAverageRatingMessage>
    {
        private readonly IFilmService _filmService;
        private readonly ILogger<UpdateAverageRatingMessageConsumer> _logger;

        public UpdateAverageRatingMessageConsumer(IFilmService filmService, ILogger<UpdateAverageRatingMessageConsumer> logger)
        {
            _filmService = filmService;
            _logger = logger;
        }

        public async Task Consume(ConsumeContext<UpdateAverageRatingMessage> context)
        {
            var film = context.Message.Adapt<RequestFilmDTO>();
            var filmId = context.Message.FilmId;

            await _filmService.UpdateAsync(filmId, film);

            _logger.LogInformation($"Average rating was successfully updated for film {filmId}");
        }
    }
}
