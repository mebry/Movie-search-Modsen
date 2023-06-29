using Mapster;
using MassTransit;
using Microsoft.Extensions.Logging;
using Reporting.BusinessLogic.DTOs.ConsumerDTOs;
using Reporting.BusinessLogic.MassTransit.Consumers.FilmConsumers;
using Reporting.BusinessLogic.Services.FilmGenreServices;
using Shared.Messages.FilmCountryMessages;

namespace Reporting.BusinessLogic.MassTransit.Consumers.FilmGenreConsumers
{
    internal class CreatedFilmGenreMessageConsumer : IConsumer<CreatedFilmGenreMessage>
    {
        private readonly IFilmGenreDataCaptureService _filmGenreDataCaptureService;
        private readonly ILogger<CreatedFilmMessageConsumer> _logger;

        public CreatedFilmGenreMessageConsumer(IFilmGenreDataCaptureService filmGenreDataCaptureService,
            ILogger<CreatedFilmMessageConsumer> logger)
        {
            _filmGenreDataCaptureService = filmGenreDataCaptureService;
            _logger = logger;
        }

        public async Task Consume(ConsumeContext<CreatedFilmGenreMessage> context)
        {
            var message = context.Message;
            var filmGenreConsumer = message.Adapt<ConsumerFilmGenreDTO>();

            await _filmGenreDataCaptureService.CreateAsync(filmGenreConsumer);

            _logger.LogInformation("Film genre was created");
        }
    }
}
