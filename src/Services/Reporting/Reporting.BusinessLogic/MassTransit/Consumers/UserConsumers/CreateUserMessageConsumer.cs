using Mapster;
using MassTransit;
using Microsoft.Extensions.Logging;
using Reporting.BusinessLogic.DTOs.ConsumerDTOs;
using Reporting.BusinessLogic.Services.UserServices;
using Shared.Messages.AuthenticationMessages;

namespace Reporting.BusinessLogic.MassTransit.Consumers.UserConsumers
{
    internal class CreateUserMessageConsumer : IConsumer<CreateUserMessage>
    {
        private readonly IUserDataCaptureService _userDataCaptureService;
        private readonly ILogger<CreateUserMessageConsumer> _logger;

        public CreateUserMessageConsumer(IUserDataCaptureService userDataCaptureService,
            ILogger<CreateUserMessageConsumer> logger)
        {
            _userDataCaptureService = userDataCaptureService;
            _logger = logger;
        }

        public async Task Consume(ConsumeContext<CreateUserMessage> context)
        {
            var message = context.Message;
            var userConsume = message.Adapt<ConsumerUserDTO>();

            await _userDataCaptureService.CreateAsync(userConsume);

            _logger.LogInformation("User was created");
        }
    }
}
