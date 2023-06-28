using MassTransit;
using Microsoft.Extensions.Logging;
using Reporting.BusinessLogic.MassTransit.Consumers.FilmConsumers;
using Reporting.BusinessLogic.Services.FilmCountryServices;
using Shared.Messages.FilmCountryMessages;

namespace Reporting.BusinessLogic.MassTransit.Consumers.FilmCountryConsumers
{
    internal class RemovedFilmCountryMessageConsumer : IConsumer<CreatedFilmCountryMessage>
    {
        private readonly IFilmCountryDataCaptureService _filmCountryDataCaptureService;
        private readonly ILogger<CreatedFilmMessageConsumer> _logger;

        public RemovedFilmCountryMessageConsumer(IFilmCountryDataCaptureService filmCountryDataCaptureService,
            ILogger<CreatedFilmMessageConsumer> logger)
        {
            _filmCountryDataCaptureService = filmCountryDataCaptureService;
            _logger = logger;
        }

        public async Task Consume(ConsumeContext<CreatedFilmCountryMessage> context)
        {
            var message = context.Message;
            var filmId = message.FilmId;
            var countryEnum = message.CountryId;

            await _filmCountryDataCaptureService.DeleteAsync(filmId, countryEnum);

            _logger.LogInformation("Film country was created");
        }
    }
}
