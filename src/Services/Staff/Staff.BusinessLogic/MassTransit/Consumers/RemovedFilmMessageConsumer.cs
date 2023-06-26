using MassTransit;
using Microsoft.Extensions.Logging;
using Shared.Messages.FilmMessages;
using Staff.BusinessLogic.Services.Interfaces;

namespace Staff.BusinessLogic.MassTransit.Consumers
{
    public class RemovedFilmMessageConsumer : IConsumer<RemovedFilmMessage>
    {
        private readonly IFilmService _filmService;
        private readonly ILogger<RemovedFilmMessageConsumer> _logger;

        public RemovedFilmMessageConsumer(IFilmService filmService, ILogger<RemovedFilmMessageConsumer> logger)
        {
            _filmService = filmService;
            _logger = logger;
        }

        public async Task Consume(ConsumeContext<RemovedFilmMessage> context)
        {
            var filmId = context.Message.Id;

            await _filmService.RemoveFilmAsync(filmId);

            _logger.LogInformation($"Film {filmId} has been successfully removed");
        }
    }
}
