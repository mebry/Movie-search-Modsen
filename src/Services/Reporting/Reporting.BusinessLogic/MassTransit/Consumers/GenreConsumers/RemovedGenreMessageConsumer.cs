using MassTransit;
using Microsoft.Extensions.Logging;
using Reporting.BusinessLogic.MassTransit.Consumers.FilmConsumers;
using Reporting.BusinessLogic.Services.GenreServices;
using Shared.Messages.GenreMessages;

namespace Reporting.BusinessLogic.MassTransit.Consumers.GenreConsumers
{
    internal class RemovedGenreMessageConsumer : IConsumer<RemovedGenreMessage>
    {
        private readonly IGenreDataCaptureService _genreDataCaptureService;
        private readonly ILogger<CreatedFilmMessageConsumer> _logger;

        public RemovedGenreMessageConsumer(IGenreDataCaptureService genreDataCaptureService,
            ILogger<CreatedFilmMessageConsumer> logger)
        {
            _genreDataCaptureService = genreDataCaptureService;
            _logger = logger;
        }

        public async Task Consume(ConsumeContext<RemovedGenreMessage> context)
        {
            var message = context.Message;
            var genreId = message.Id;

            await _genreDataCaptureService.DeleteAsync(genreId);

            _logger.LogInformation("Genre was removed");
        }
    }
}
