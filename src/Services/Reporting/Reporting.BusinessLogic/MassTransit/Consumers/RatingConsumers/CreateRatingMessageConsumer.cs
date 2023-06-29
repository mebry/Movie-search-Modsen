using Mapster;
using MassTransit;
using Microsoft.Extensions.Logging;
using Reporting.BusinessLogic.DTOs.ConsumerDTOs;
using Reporting.BusinessLogic.Services.RatingServices;
using Shared.Messages.RatingMessages;

namespace Reporting.BusinessLogic.MassTransit.Consumers.RatingConsumers
{
    internal class CreateRatingMessageConsumer : IConsumer<CreateRatingMessage>
    {
        private readonly IRatingDataCaptureService _ratingDataCaptureService;
        private readonly ILogger<CreateRatingMessageConsumer> _logger;

        public CreateRatingMessageConsumer(IRatingDataCaptureService ratingDataCaptureService,
            ILogger<CreateRatingMessageConsumer> logger)
        {
            _ratingDataCaptureService = ratingDataCaptureService;
            _logger = logger;
        }

        public async Task Consume(ConsumeContext<CreateRatingMessage> context)
        {
            var ratingConsumer = context.Message.Adapt<ConsumerRatingDTO>();

            await _ratingDataCaptureService.CreateAsync(ratingConsumer);

            _logger.LogInformation("Rating was created");
        }
    }
}