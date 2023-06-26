using Mapster;
using MassTransit;
using Microsoft.Extensions.Logging;
using Rating.DataAccess.Entities;
using Rating.DataAccess.Repositories.FilmRepositories;
using Shared.Messages.FilmMessages;

namespace Rating.BusinessLogic.MassTransit.Consumers
{
    public class DeleteFilmMessageConsimer : IConsumer<RemovedFilmMessage>
    {
        private readonly IFilmRepository _filmRepository;
        private readonly ILogger<CreateFilmMessageConsumer> _logger;

        public DeleteFilmMessageConsimer(IFilmRepository filmRepository, ILogger<CreateFilmMessageConsumer> logger)
        {
            _filmRepository = filmRepository;
            _logger = logger;
        }

        public async Task Consume(ConsumeContext<RemovedFilmMessage> context)
        {
            var film = context.Adapt<Film>();

            _filmRepository.Delete(film);

            await _filmRepository.SaveAsync();

            _logger.LogInformation("Film was deleted");
        }
    }
}
