using Mapster;
using MassTransit;
using Microsoft.Extensions.Logging;
using Reporting.BusinessLogic.DTOs.ConsumerDTOs;
using Reporting.BusinessLogic.Services.FilmServices;
using Shared.Messages.FilmMessages;

namespace Reporting.BusinessLogic.MassTransit.Consumers.FilmConsumers
{
    internal class UpdateFilmMessageConsumer : IConsumer<UpdatedFilmMessage>
    {
        private readonly IFilmDataCaptureService _filmService;
        private readonly ILogger<CreateFilmMessageConsumer> _logger;

        public UpdateFilmMessageConsumer(IFilmDataCaptureService filmService, ILogger<CreateFilmMessageConsumer> logger)
        {
            _filmService = filmService;
            _logger = logger;
        }

        public async Task Consume(ConsumeContext<UpdatedFilmMessage> context)
        {
            var filmConsumer = context.Message.Adapt<ConsumerFilmDTO>();

            await _filmService.UpdateAsync(filmConsumer);

            _logger.LogInformation("Film was created");
        }
    }
}
