using Mapster;
using MassTransit;
using Microsoft.Extensions.Logging;
using Reporting.BusinessLogic.DTOs.ConsumerDTOs;
using Reporting.BusinessLogic.Services.FilmServices;
using Shared.Messages.FilmMessages;

namespace Reporting.BusinessLogic.MassTransit.Consumers.FilmConsumers
{
    internal class UpdatedFilmMessageConsumer : IConsumer<UpdatedFilmMessage>
    {
        private readonly IFilmDataCaptureService _filmService;
        private readonly ILogger<UpdatedFilmMessageConsumer> _logger;

        public UpdatedFilmMessageConsumer(IFilmDataCaptureService filmService,
            ILogger<UpdatedFilmMessageConsumer> logger)
        {
            _filmService = filmService;
            _logger = logger;
        }

        public async Task Consume(ConsumeContext<UpdatedFilmMessage> context)
        {
            var filmConsumer = context.Message.Adapt<ConsumerFilmDTO>();

            await _filmService.UpdateAsync(filmConsumer);

            _logger.LogInformation("Film was updated");
        }
    }
}
