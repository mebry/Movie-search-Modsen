using Mapster;
using MassTransit;
using Microsoft.Extensions.Logging;
using Reporting.BusinessLogic.DTOs.ConsumerDTOs;
using Reporting.BusinessLogic.MassTransit.Consumers.FilmConsumers;
using Reporting.BusinessLogic.Services.GenreServices;
using Shared.Messages.GenreMessages;

namespace Reporting.BusinessLogic.MassTransit.Consumers.GenreConsumers
{
    internal class UpdatedGenreMessageConsumer : IConsumer<UpdatedGenreMessage>
    {
        private readonly IGenreDataCaptureService _genreDataCaptureService;
        private readonly ILogger<CreatedFilmMessageConsumer> _logger;

        public UpdatedGenreMessageConsumer(IGenreDataCaptureService genreDataCaptureService,
            ILogger<CreatedFilmMessageConsumer> logger)
        {
            _genreDataCaptureService = genreDataCaptureService;
            _logger = logger;
        }

        public async Task Consume(ConsumeContext<UpdatedGenreMessage> context)
        {
            var message = context.Message;
            var genreConsumer = message.Adapt<ConsumerGenreDTO>();

            await _genreDataCaptureService.UpdateAsync(genreConsumer);

            _logger.LogInformation("Genre was updated");
        }
    }
}
