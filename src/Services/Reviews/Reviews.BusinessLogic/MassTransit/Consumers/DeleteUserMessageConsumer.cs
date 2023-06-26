using MassTransit;
using Microsoft.Extensions.Logging;
using Reviews.BusinessLogic.Services.Interfaces;
using Shared.Messages.AuthenticationMessages;

namespace Reviews.BusinessLogic.MassTransit.Consumers
{
    public class DeleteUserMessageConsumer : IConsumer<DeleteUserMessage>
    {
        private readonly ICriticService _criticService;
        private readonly ILogger<DeleteUserMessageConsumer> _logger;

        public DeleteUserMessageConsumer(ICriticService criticService, ILogger<DeleteUserMessageConsumer> logger)
        {
            _criticService = criticService;
            _logger = logger;
        }

        public async Task Consume(ConsumeContext<DeleteUserMessage> context)
        {
            var criticId = context.Message.Id;

            await _criticService.RemoveCriticAsync(criticId);

            _logger.LogInformation($"User {criticId} has been successfully deleted");
        }
    }
}
