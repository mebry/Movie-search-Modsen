using MassTransit;
using Microsoft.Extensions.Logging;
using Reporting.BusinessLogic.Services.UserServices;
using Shared.Messages.AuthenticationMessages;

namespace Reporting.BusinessLogic.MassTransit.Consumers.UserConsumers
{
    internal class DeleteUserMessageConsumer : IConsumer<DeleteUserMessage>
    {
        private readonly IUserDataCaptureService _userDataCaptureService;
        private readonly ILogger<DeleteUserMessageConsumer> _logger;

        public DeleteUserMessageConsumer(IUserDataCaptureService userDataCaptureService,
            ILogger<DeleteUserMessageConsumer> logger)
        {
            _userDataCaptureService = userDataCaptureService;
            _logger = logger;
        }

        public async Task Consume(ConsumeContext<DeleteUserMessage> context)
        {
            var message = context.Message;
            var userId = message.Id;

            await _userDataCaptureService.DeleteAsync(userId);

            _logger.LogInformation("User was removed");
        }
    }
}
