using FilmCollection.DataAccess.Models;
using FilmCollection.DataAccess.Repositories.Interfaces;
using MapsterMapper;
using MassTransit;
using Microsoft.Extensions.Logging;
using Shared.Messages.GenreMessages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmCollection.BusinessLogic.MassTransit.Consumers.GenreMessageConsumers
{
    public class CreateGenreMessageConsumer : IConsumer<CreatedGenreMessage>
    {
        private readonly IGenreRepository _genreRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateGenreMessageConsumer> _logger;

        public CreateGenreMessageConsumer(IGenreRepository genreRepository,
            IMapper mapper,
            ILogger<CreateGenreMessageConsumer> logger)
        {
            _genreRepository = genreRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task Consume(ConsumeContext<CreatedGenreMessage> context)
        {
            var mappedMessage = _mapper.Map<Genre>(context.Message);
            await _genreRepository.CreateGenreAsync(mappedMessage);

            _logger.LogInformation($"A new genre with {context.Message.Id} id was successfully created");

        }
    }
}
