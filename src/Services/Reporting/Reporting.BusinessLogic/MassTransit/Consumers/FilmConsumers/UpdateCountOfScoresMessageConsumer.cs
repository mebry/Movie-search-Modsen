using Mapster;
using MassTransit;
using Microsoft.Extensions.Logging;
using Reporting.BusinessLogic.DTOs.ConsumerDTOs;
using Reporting.BusinessLogic.Services.FilmServices;
using Shared.Messages.RatingMessages;

namespace Reporting.BusinessLogic.MassTransit.Consumers.FilmConsumers
{
    internal class UpdateCountOfScoresMessageConsumer : IConsumer<UpdateCountOfScoresMessage>
    {
        private readonly IFilmDataCaptureService _filmService;
        private readonly ILogger<UpdateCountOfScoresMessageConsumer> _logger;

        public UpdateCountOfScoresMessageConsumer(IFilmDataCaptureService filmService,
            ILogger<UpdateCountOfScoresMessageConsumer> logger)
        {
            _filmService = filmService;
            _logger = logger;
        }

        public async Task Consume(ConsumeContext<UpdateCountOfScoresMessage> context)
        {
            var countOfScoresConsumer = context.Message.Adapt<ConsumerCountOfScoresDTO>();

            await _filmService.UpdateCountOfScoresAsync(countOfScoresConsumer);

            _logger.LogInformation("Film was updated");
        }
    }
}
