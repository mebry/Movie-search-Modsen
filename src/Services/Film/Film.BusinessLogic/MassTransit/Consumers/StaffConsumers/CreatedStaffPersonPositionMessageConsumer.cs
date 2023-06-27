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
    /// Represents a message consumer for handling created staff person position messages.
    /// </summary>
    public class CreatedStaffPersonPositionMessageConsumer : IConsumer<CreatedStaffPersonPositionMessage>
    {
        private readonly IStaffPersonPositionRepository _staffPersonPositionRepository;
        private readonly ILogger<CreatedStaffPersonPositionMessageConsumer> _logger;

        public CreatedStaffPersonPositionMessageConsumer(IStaffPersonPositionRepository staffPersonPositionRepository, 
            ILogger<CreatedStaffPersonPositionMessageConsumer> logger)
        {
            _staffPersonPositionRepository = staffPersonPositionRepository;
            _logger = logger;
        }

        /// <summary>
        /// Consumes the specified message.
        /// </summary>
        /// <param name="context">The message context.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task Consume(ConsumeContext<CreatedStaffPersonPositionMessage> context)
        {
            var message = context.Message;
            var mappedModel = message.Adapt<StaffPersonPosition>();
            _staffPersonPositionRepository.Create(mappedModel);

            await _staffPersonPositionRepository.SaveChangesAsync();

            _logger.LogInformation($"The new person with Id: {message.StaffPersonId} and position Id: {message.PositionId} " +
                $"has been successfully added to the film with Id: {message.FilmId}.");
        }
    }
}
