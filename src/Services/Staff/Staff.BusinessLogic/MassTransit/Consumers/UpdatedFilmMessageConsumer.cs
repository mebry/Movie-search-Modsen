using MassTransit;
using Microsoft.Extensions.Logging;
using Shared.Messages.FilmMessages;
using Staff.BusinessLogic.DTOs;
using Staff.BusinessLogic.Services.Interfaces;

namespace Staff.BusinessLogic.MassTransit.Consumers
{
    public class UpdatedFilmMessageConsumer : IConsumer<UpdatedFilmMessage>
    {
        private readonly IFilmService _filmService;
        private readonly ILogger<UpdatedFilmMessageConsumer> _logger;

        public UpdatedFilmMessageConsumer(IFilmService filmService, ILogger<UpdatedFilmMessageConsumer> logger)
        {
            _filmService = filmService;
            _logger = logger;
        }

        public async Task Consume(ConsumeContext<UpdatedFilmMessage> context)
        {
            var film = new RequestFilmDTO
            {
                Title = context.Message.Title,
                ReleaseDate = Convert.ToDateTime(context.Message.ReleaseDate),
                AverageRating = 0,
                CountOfScores = 0
            };
            var filmId = context.Message.Id;

            await _filmService.UpdateAsync(filmId, film);

            _logger.LogInformation($"Film {filmId} has been successfully updated");
        }
    }
}
