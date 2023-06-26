using Mapster;
using MassTransit;
using Microsoft.Extensions.Logging;
using Rating.DataAccess.Entities;
using Rating.DataAccess.Repositories.FilmRepositories;
using Shared.Messages.FilmMessages;

namespace Rating.BusinessLogic.MassTransit.Consumers
{
    public class UpdateFilmMessageConsumer : IConsumer<UpdatedFilmMessage>
    {
        private readonly IFilmRepository _filmRepository;
        private readonly ILogger<CreateFilmMessageConsumer> _logger;

        public UpdateFilmMessageConsumer(IFilmRepository filmRepository, ILogger<CreateFilmMessageConsumer> logger)
        {
            _filmRepository = filmRepository;
            _logger = logger;
        }

        public async Task Consume(ConsumeContext<UpdatedFilmMessage> context)
        {
            var film = context.Adapt<Film>();

            _filmRepository.Update(film);

            await _filmRepository.SaveAsync();

            _logger.LogInformation("Film was updated");
        }
    }
}
