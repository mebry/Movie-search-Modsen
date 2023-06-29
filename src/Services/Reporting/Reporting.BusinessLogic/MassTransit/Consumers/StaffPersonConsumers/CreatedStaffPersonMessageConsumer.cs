using Mapster;
using MassTransit;
using Microsoft.Extensions.Logging;
using Reporting.BusinessLogic.DTOs.ConsumerDTOs;
using Reporting.BusinessLogic.Services.StaffPersonServices;
using Shared.Messages.StaffMessages;

namespace Reporting.BusinessLogic.MassTransit.Consumers.StaffPersonConsumers
{
    internal class CreatedStaffPersonMessageConsumer : IConsumer<CreatedStaffPersonMessage>
    {
        private readonly IStaffPersonDataCaptureService _staffPersonDataCaptureService;
        private readonly ILogger<CreatedStaffPersonMessageConsumer> _logger;

        public CreatedStaffPersonMessageConsumer(IStaffPersonDataCaptureService staffPersonDataCaptureService,
            ILogger<CreatedStaffPersonMessageConsumer> logger)
        {
            _staffPersonDataCaptureService = staffPersonDataCaptureService;
            _logger = logger;
        }

        public async Task Consume(ConsumeContext<CreatedStaffPersonMessage> context)
        {
            var staffPersonComsumer = context.Message.Adapt<ConsumerStaffPersonDTO>();

            await _staffPersonDataCaptureService.CreateAsync(staffPersonComsumer);

            _logger.LogInformation("Staff person was created");
        }
    }
}
