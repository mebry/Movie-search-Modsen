using Mapster;
using MassTransit;
using Microsoft.Extensions.Logging;
using Shared.Messages.RatingMessages;
using Staff.BusinessLogic.DTOs;
using Staff.BusinessLogic.Services.Interfaces;

namespace Staff.BusinessLogic.MassTransit.Consumers
{
    public class UpdateCountOfScoresMessageConsumer : IConsumer<UpdateCountOfScoresMessage>
    {
        private readonly IFilmService _filmService;
        private readonly ILogger<UpdateCountOfScoresMessageConsumer> _logger;

        public UpdateCountOfScoresMessageConsumer(IFilmService filmService, ILogger<UpdateCountOfScoresMessageConsumer> logger)
        {
            _filmService = filmService;
            _logger = logger;
        }

        public async Task Consume(ConsumeContext<UpdateCountOfScoresMessage> context)
        {
            var film = context.Message.Adapt<RequestFilmDTO>();
            var filmId = context.Message.FilmId;

            await _filmService.UpdateAsync(filmId, film);

            _logger.LogInformation($"Count of scores was successfully updated for film {filmId}");
        }
    }
}
