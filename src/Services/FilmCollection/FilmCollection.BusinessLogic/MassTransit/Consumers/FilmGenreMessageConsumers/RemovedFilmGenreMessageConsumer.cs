using FilmCollection.DataAccess.Repositories.Interfaces;
using MassTransit;
using Shared.Messages.FilmCountryMessages;
using FilmCollection.DataAccess.Models;
using MapsterMapper;
using Microsoft.Extensions.Logging;

namespace FilmCollection.BusinessLogic.MassTransit.Consumers.FilmGenreMessageConsumers
{
    public class RemovedFilmGenreMessageConsumer : IConsumer<RemovedFilmGenreMessage>
    {
        private readonly IFilmGenreRepository _filmGenreRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<RemovedFilmGenreMessageConsumer> _logger;

        public RemovedFilmGenreMessageConsumer(IFilmGenreRepository filmGenreRepository,
            IMapper mapper,
            ILogger<RemovedFilmGenreMessageConsumer> logger)
        {
            _filmGenreRepository = filmGenreRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task Consume(ConsumeContext<RemovedFilmGenreMessage> context)
        {
            await _filmGenreRepository.DeleteFilmGenreAsync(_mapper.Map<FilmGenre>(context.Message));

            _logger.LogInformation($"Film genre association with {context.Message.FilmId} film id and {context.Message.GenreId} genre id was successfully deleted");
        }
    }
}
