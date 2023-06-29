using MassTransit;
using Microsoft.Extensions.Logging;
using Reporting.BusinessLogic.MassTransit.Consumers.FilmConsumers;
using Reporting.BusinessLogic.Services.FilmGenreServices;
using Shared.Messages.FilmCountryMessages;

namespace Reporting.BusinessLogic.MassTransit.Consumers.FilmGenreConsumers
{
    internal class RemovedFilmGenreMessageConsumer : IConsumer<RemovedFilmGenreMessage>
    {
        private readonly IFilmGenreDataCaptureService _filmGenreDataCaptureService;
        private readonly ILogger<CreatedFilmMessageConsumer> _logger;

        public RemovedFilmGenreMessageConsumer(IFilmGenreDataCaptureService filmGenreDataCaptureService,
            ILogger<CreatedFilmMessageConsumer> logger)
        {
            _filmGenreDataCaptureService = filmGenreDataCaptureService;
            _logger = logger;
        }

        public async Task Consume(ConsumeContext<RemovedFilmGenreMessage> context)
        {
            var message = context.Message;
            var filmId = message.FilmId;
            var genreId = message.GenreId;

            await _filmGenreDataCaptureService.DeleteAsync(filmId, genreId);

            _logger.LogInformation("Film genre was removed");
        }
    }
}
