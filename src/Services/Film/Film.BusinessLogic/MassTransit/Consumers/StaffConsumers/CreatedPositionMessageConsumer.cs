using Film.BusinessLogic.MassTransit.Consumers.RatingConsumers;
using Film.DataAccess.Entities;
using Film.DataAccess.Repositories.Implementations;
using Film.DataAccess.Repositories.Interfaces;
using Mapster;
using MassTransit;
using Microsoft.Extensions.Logging;
using Shared.Messages.StaffMessages;

namespace Film.BusinessLogic.MassTransit.Consumers.StaffConsumers
{
    /// <summary>
    /// Represents a message consumer for handling created position messages.
    /// </summary>
    public class CreatedPositionMessageConsumer : IConsumer<CreatedPositionMessage>
    {
        private readonly IPositionRepository _positionRepository;
        private readonly ILogger<CreatedPositionMessageConsumer> _logger;

        public CreatedPositionMessageConsumer(IPositionRepository positionRepository, 
            ILogger<CreatedPositionMessageConsumer> logger)
        {
            _positionRepository = positionRepository;
            _logger = logger;
        }

        /// <summary>
        /// Consumes the specified message.
        /// </summary>
        /// <param name="context">The message context.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task Consume(ConsumeContext<CreatedPositionMessage> context)
        {
            var message = context.Message;
            var mappedModel = message.Adapt<Position>();
            _positionRepository.Create(mappedModel);

            await _positionRepository.SaveChangesAsync();

            _logger.LogInformation($"A new position with id: {mappedModel.Id} was successfully added");
        }
    }
}
