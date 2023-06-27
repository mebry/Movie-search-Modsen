using Mapster;
using MassTransit;
using Microsoft.Extensions.Logging;
using Reviews.DataAccess.Entities;
using Reviews.DataAccess.Repositories.Interfaces;
using Shared.Messages.AuthenticationMessages;

namespace Reviews.BusinessLogic.MassTransit.Consumers
{
    public class CreateUserMessageConsumer : IConsumer<CreateUserMessage>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<CreateUserMessageConsumer> _logger;

        public CreateUserMessageConsumer(IUnitOfWork unitOfWork, ILogger<CreateUserMessageConsumer> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task Consume(ConsumeContext<CreateUserMessage> context)
        {
            var critic = context.Message.Adapt<Critic>();

            await _unitOfWork.CriticRepository.CreateAsync(critic);
            await _unitOfWork.SaveChangesAsync();

            _logger.LogInformation($"User {context.Message.Id} has been successfully created");
        }
    }
}
