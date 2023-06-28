using MassTransit;
using Microsoft.Extensions.Logging;
using Reporting.BusinessLogic.Services.FilmServices;
using Shared.Messages.FilmMessages;

namespace Reporting.BusinessLogic.MassTransit.Consumers.FilmConsumers
{
    internal class RemovedFilmMessageConsumer : IConsumer<RemovedFilmMessage>
    {
        private readonly IFilmDataCaptureService _filmService;
        private readonly ILogger<CreatedFilmMessageConsumer> _logger;

        public RemovedFilmMessageConsumer(IFilmDataCaptureService filmService, ILogger<CreatedFilmMessageConsumer> logger)
        {
            _filmService = filmService;
            _logger = logger;
        }

        public async Task Consume(ConsumeContext<RemovedFilmMessage> context)
        {
            Guid filmId = context.Message.Id;

            await _filmService.DeleteAsync(filmId);

            _logger.LogInformation("Film was created");
        }
    }
}
