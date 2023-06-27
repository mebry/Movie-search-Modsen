using FilmCollection.DataAccess.Models;
using FilmCollection.DataAccess.Repositories.Interfaces;
using MapsterMapper;
using MassTransit;
using Microsoft.Extensions.Logging;
using Shared.Messages.GenreMessages;

namespace FilmCollection.BusinessLogic.MassTransit.Consumers.GenreMessageConsumers
{
    public class UpdateGenreMessageConsumer : IConsumer<UpdatedGenreMessage>
    {
        private readonly IGenreRepository _genreRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<UpdateGenreMessageConsumer> _logger;

        public UpdateGenreMessageConsumer(IGenreRepository genreRepository, IMapper mapper, ILogger<UpdateGenreMessageConsumer> logger)
        {
            _genreRepository = genreRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task Consume(ConsumeContext<UpdatedGenreMessage> context)
        {
            await _genreRepository.UpdateGenreAsync(_mapper.Map<Genre>(context.Message));

            _logger.LogInformation($"The genre with {context.Message.Id} id was successfully updated");
        }
    }
}
