using Mapster;
using MassTransit;
using Microsoft.Extensions.Logging;
using Reporting.BusinessLogic.DTOs.ConsumerDTOs;
using Reporting.BusinessLogic.MassTransit.Consumers.FilmConsumers;
using Reporting.BusinessLogic.Services.GenreServices;
using Shared.Messages.GenreMessages;

namespace Reporting.BusinessLogic.MassTransit.Consumers.GenreConsumers
{
    internal class CreatedGenreMessageConsumer : IConsumer<CreatedGenreMessage>
    {
        private readonly IGenreDataCaptureService _genreDataCaptureService;
        private readonly ILogger<CreatedFilmMessageConsumer> _logger;

        public CreatedGenreMessageConsumer(IGenreDataCaptureService genreDataCaptureService,
            ILogger<CreatedFilmMessageConsumer> logger)
        {
            _genreDataCaptureService = genreDataCaptureService;
            _logger = logger;
        }

        public async Task Consume(ConsumeContext<CreatedGenreMessage> context)
        {
            var message = context.Message;
            var genreConsumer = message.Adapt<ConsumerGenreDTO>();

            await _genreDataCaptureService.CreateAsync(genreConsumer);

            _logger.LogInformation("Genre was created");
        }
    }
}
