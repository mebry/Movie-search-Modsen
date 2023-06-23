using MassTransit;
using Microsoft.Extensions.Logging;
using Rating.DataAccess.Entities;
using Rating.DataAccess.Repositories.FilmRepositories;
using Shared.Messages.FilmMessages;

namespace Rating.BusinessLogic.MassTransit.Consumers
{
    public class CreateFilmMessageConsumer : IConsumer<CreatedFilmMessage>
    {
        private readonly IFilmRepository _filmRepository;
        private readonly ILogger<CreateFilmMessageConsumer> _logger;

        public CreateFilmMessageConsumer(IFilmRepository filmRepository, ILogger<CreateFilmMessageConsumer> logger)
        {
            _filmRepository = filmRepository;
            _logger = logger;
        }

        public async Task Consume(ConsumeContext<CreatedFilmMessage> context)
        {
            var film = new Film
            {
                Id = context.Message.Id
            };

            _filmRepository.Create(film);

            await _filmRepository.SaveAsync();

            _logger.LogInformation("Film was created");
        }
    }
}
