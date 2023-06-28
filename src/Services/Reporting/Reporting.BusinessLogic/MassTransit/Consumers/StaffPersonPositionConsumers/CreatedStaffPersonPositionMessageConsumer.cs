using Mapster;
using MassTransit;
using Microsoft.Extensions.Logging;
using Reporting.BusinessLogic.DTOs.ConsumerDTOs;
using Reporting.BusinessLogic.MassTransit.Consumers.StaffPersonConsumers;
using Reporting.BusinessLogic.Services.StaffPersonPositionServices;
using Shared.Messages.StaffMessages;

namespace Reporting.BusinessLogic.MassTransit.Consumers.StaffPersonPositionConsumers
{
    internal class CreatedStaffPersonPositionMessageConsumer : IConsumer<CreatedStaffPersonPositionMessage>
    {
        private readonly IStaffPersonPositionDataCaptureService _staffPersonPositionDataCaptureService;
        private readonly ILogger<CreatedStaffPersonMessageConsumer> _logger;

        public CreatedStaffPersonPositionMessageConsumer(IStaffPersonPositionDataCaptureService staffPersonPositionDataCaptureService,
            ILogger<CreatedStaffPersonMessageConsumer> logger)
        {
            _staffPersonPositionDataCaptureService = staffPersonPositionDataCaptureService;
            _logger = logger;
        }

        public async Task Consume(ConsumeContext<CreatedStaffPersonPositionMessage> context)
        {
            var message = context.Message;
            var staffPersonComsumer = message.Adapt<ConsumerStaffPersonPositionDTO>();

            await _staffPersonPositionDataCaptureService.CreateAsync(staffPersonComsumer);

            _logger.LogInformation("Staff person position was created");
        }
    }
}
