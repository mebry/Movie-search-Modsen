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
    /// Represents a message consumer for handling update staff person messages.
    /// </summary>
    public class UpdateStaffPersonMessageConsumer : IConsumer<UpdateStaffPersonMessage>
    {
        private readonly IStaffPersonRepository _staffPersonRepository;
        private readonly ILogger<UpdateStaffPersonMessageConsumer> _logger;

        public UpdateStaffPersonMessageConsumer(IStaffPersonRepository staffPersonRepository,
            ILogger<UpdateStaffPersonMessageConsumer> logger)
        {
            _staffPersonRepository = staffPersonRepository;
            _logger = logger;
        }

        /// <summary>
        /// Consumes the specified message.
        /// </summary>
        /// <param name="context">The message context.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task Consume(ConsumeContext<UpdateStaffPersonMessage> context)
        {
            var message = context.Message;
            var mappedModel = message.Adapt<StaffPerson>();

            _staffPersonRepository.Update(mappedModel);

            await _staffPersonRepository.SaveChangesAsync();

            _logger.LogInformation($"The person with id: {mappedModel.Id} was successfully updated");
        }
    }
}
