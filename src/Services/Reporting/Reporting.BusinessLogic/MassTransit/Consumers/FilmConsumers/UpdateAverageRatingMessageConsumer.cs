using Mapster;
using MassTransit;
using Microsoft.Extensions.Logging;
using Reporting.BusinessLogic.DTOs.ConsumerDTOs;
using Reporting.BusinessLogic.Services.FilmServices;
using Shared.Messages.RatingMessages;

namespace Reporting.BusinessLogic.MassTransit.Consumers.FilmConsumers
{
    internal class UpdateAverageRatingMessageConsumer : IConsumer<UpdateAverageRatingMessage>
    {
        private readonly IFilmDataCaptureService _filmService;
        private readonly ILogger<UpdateAverageRatingMessageConsumer> _logger;

        public UpdateAverageRatingMessageConsumer(IFilmDataCaptureService filmService,
            ILogger<UpdateAverageRatingMessageConsumer> logger)
        {
            _filmService = filmService;
            _logger = logger;
        }

        public async Task Consume(ConsumeContext<UpdateAverageRatingMessage> context)
        {
            var averageRatingConsumer = context.Message.Adapt<ConsumerAverageRatingDTO>();

            await _filmService.UpdateAverageRatingAsync(averageRatingConsumer);

            _logger.LogInformation("Film was updated");
        }
    }
}
