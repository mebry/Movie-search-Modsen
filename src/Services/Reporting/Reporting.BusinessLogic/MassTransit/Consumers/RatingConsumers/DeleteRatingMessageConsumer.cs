using MassTransit;
using Microsoft.Extensions.Logging;
using Reporting.BusinessLogic.Services.RatingServices;
using Shared.Messages.RatingMessages;

namespace Reporting.BusinessLogic.MassTransit.Consumers.RatingConsumers
{
    internal class DeleteRatingMessageConsumer : IConsumer<DeleteRatingMessage>
    {
        private readonly IRatingDataCaptureService _ratingDataCaptureService;
        private readonly ILogger<DeleteRatingMessageConsumer> _logger;

        public DeleteRatingMessageConsumer(IRatingDataCaptureService ratingDataCaptureService,
            ILogger<DeleteRatingMessageConsumer> logger)
        {
            _ratingDataCaptureService = ratingDataCaptureService;
            _logger = logger;
        }

        public async Task Consume(ConsumeContext<DeleteRatingMessage> context)
        {
            var message = context.Message;
            var ratingId = message.Id;

            await _ratingDataCaptureService.DeleteAsync(ratingId);

            _logger.LogInformation("Rating was removed");
        }
    }
}