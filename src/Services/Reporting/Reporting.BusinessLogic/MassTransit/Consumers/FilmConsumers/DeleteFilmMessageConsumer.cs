using MassTransit;
using Microsoft.Extensions.Logging;
using Reporting.BusinessLogic.Services.FilmServices;
using Shared.Messages.FilmMessages;

namespace Reporting.BusinessLogic.MassTransit.Consumers.FilmConsumers
{
    internal class DeleteFilmMessageConsumer : IConsumer<RemovedFilmMessage>
    {
        private readonly IFilmDataCaptureService _filmService;
        private readonly ILogger<CreateFilmMessageConsumer> _logger;

        public DeleteFilmMessageConsumer(IFilmDataCaptureService filmService, ILogger<CreateFilmMessageConsumer> logger)
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
