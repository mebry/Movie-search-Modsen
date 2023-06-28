using Mapster;
using MassTransit;
using Microsoft.Extensions.Logging;
using Reporting.BusinessLogic.DTOs.ConsumerDTOs;
using Reporting.BusinessLogic.Services.FilmServices;
using Shared.Messages.FilmMessages;

namespace Reporting.BusinessLogic.MassTransit.Consumers.FilmConsumers
{
    internal class CreateFilmMessageConsumer : IConsumer<CreatedFilmMessage>
    {
        private readonly IFilmDataCaptureService _filmService;
        private readonly ILogger<CreateFilmMessageConsumer> _logger;

        public CreateFilmMessageConsumer(IFilmDataCaptureService filmService, ILogger<CreateFilmMessageConsumer> logger)
        {
            _filmService = filmService;
            _logger = logger;
        }

        public async Task Consume(ConsumeContext<CreatedFilmMessage> context)
        {
            var filmConsumer = context.Message.Adapt<ConsumerFilmDTO>();

            await _filmService.CreateAsync(filmConsumer);

            _logger.LogInformation("Film was created");
        }
    }
}
