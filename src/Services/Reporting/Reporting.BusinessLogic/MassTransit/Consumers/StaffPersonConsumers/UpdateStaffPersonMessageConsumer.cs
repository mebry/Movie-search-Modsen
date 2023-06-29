using Mapster;
using MassTransit;
using Microsoft.Extensions.Logging;
using Reporting.BusinessLogic.DTOs.ConsumerDTOs;
using Reporting.BusinessLogic.Services.StaffPersonServices;
using Shared.Messages.StaffMessages;

namespace Reporting.BusinessLogic.MassTransit.Consumers.StaffPersonConsumers
{
    internal class UpdateStaffPersonMessageConsumer : IConsumer<UpdateStaffPersonMessage>
    {
        private readonly IStaffPersonDataCaptureService _staffPersonDataCaptureService;
        private readonly ILogger<UpdateStaffPersonMessageConsumer> _logger;

        public UpdateStaffPersonMessageConsumer(IStaffPersonDataCaptureService staffPersonDataCaptureService,
            ILogger<UpdateStaffPersonMessageConsumer> logger)
        {
            _staffPersonDataCaptureService = staffPersonDataCaptureService;
            _logger = logger;
        }

        public async Task Consume(ConsumeContext<UpdateStaffPersonMessage> context)
        {
            var message = context.Message;
            var staffPersonComsumer = message.Adapt<ConsumerStaffPersonDTO>();

            await _staffPersonDataCaptureService.UpdateAsync(staffPersonComsumer);

            _logger.LogInformation("Staff person was updated");
        }
    }
}
