using Mapster;
using MassTransit;
using Microsoft.Extensions.Logging;
using Reporting.BusinessLogic.DTOs.ConsumerDTOs;
using Reporting.BusinessLogic.MassTransit.Consumers.FilmConsumers;
using Reporting.BusinessLogic.Services.FilmCountryServices;
using Shared.Messages.FilmCountryMessages;

namespace Reporting.BusinessLogic.MassTransit.Consumers.FilmCountryConsumers
{
    internal class CreatedFilmCountryMessageConsumer : IConsumer<CreatedFilmCountryMessage>
    {
        private readonly IFilmCountryDataCaptureService _filmCountryDataCaptureService;
        private readonly ILogger<CreatedFilmMessageConsumer> _logger;

        public CreatedFilmCountryMessageConsumer(IFilmCountryDataCaptureService filmCountryDataCaptureService,
            ILogger<CreatedFilmMessageConsumer> logger)
        {
            _filmCountryDataCaptureService = filmCountryDataCaptureService;
            _logger = logger;
        }

        public async Task Consume(ConsumeContext<CreatedFilmCountryMessage> context)
        {
            var message = context.Message;
            var filmConsumer = message.Adapt<ConsumerFilmCountryDTO>();

            await _filmCountryDataCaptureService.CreateAsync(filmConsumer);

            _logger.LogInformation("Film country was created");
        }
    }
}