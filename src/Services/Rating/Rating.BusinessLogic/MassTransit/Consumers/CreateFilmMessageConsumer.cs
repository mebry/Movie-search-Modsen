using Mapster;
using MassTransit;
using Microsoft.Extensions.Logging;
using Rating.BusinessLogic.DTOs;
using Rating.BusinessLogic.Services.FilmServices;
using Shared.Messages.FilmMessages;

namespace Rating.BusinessLogic.MassTransit.Consumers
{
    public class CreateFilmMessageConsumer : IConsumer<CreatedFilmMessage>
    {
        private readonly IFilmService _filmService;
        private readonly ILogger<CreateFilmMessageConsumer> _logger;

        public CreateFilmMessageConsumer(IFilmService filmService, ILogger<CreateFilmMessageConsumer> logger)
        {
            _filmService = filmService;
            _logger = logger;
        }

        public async Task Consume(ConsumeContext<CreatedFilmMessage> context)
        {
            await _filmService.CreateAsync(context.Message.Id);
            _logger.LogInformation("Film was created");
        }
    }
}
