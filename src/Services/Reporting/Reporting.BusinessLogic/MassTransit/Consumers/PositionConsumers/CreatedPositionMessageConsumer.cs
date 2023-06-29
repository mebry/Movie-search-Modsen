using Mapster;
using MassTransit;
using Microsoft.Extensions.Logging;
using Reporting.BusinessLogic.DTOs.ConsumerDTOs;
using Reporting.BusinessLogic.MassTransit.Consumers.FilmConsumers;
using Reporting.BusinessLogic.Services.PositionServices;
using Shared.Messages.StaffMessages;

namespace Reporting.BusinessLogic.MassTransit.Consumers.PositionConsumers
{
    internal class CreatedPositionMessageConsumer : IConsumer<CreatedPositionMessage>
    {
        private readonly IPositionDataCaptureService _positionDataCaptureService;
        private readonly ILogger<CreatedFilmMessageConsumer> _logger;

        public CreatedPositionMessageConsumer(IPositionDataCaptureService positionDataCaptureService,
            ILogger<CreatedFilmMessageConsumer> logger)
        {
            _positionDataCaptureService = positionDataCaptureService;
            _logger = logger;
        }

        public async Task Consume(ConsumeContext<CreatedPositionMessage> context)
        {
            var message = context.Message;
            var positionConsumer = message.Adapt<ConsumerPositionDTO>();

            await _positionDataCaptureService.CreateAsync(positionConsumer);

            _logger.LogInformation("Position was created");
        }
    }
}
