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
    public class DeleteGenreMessageConsumer : IConsumer<RemovedGenreMessage>
    {
        private readonly IGenreRepository _genreRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<DeleteGenreMessageConsumer> _logger;

        public DeleteGenreMessageConsumer(IGenreRepository genreRepository, IMapper mapper, ILogger<DeleteGenreMessageConsumer> logger)
        {
            _genreRepository = genreRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task Consume(ConsumeContext<RemovedGenreMessage> context)
        {
            await _genreRepository.DeleteGenreAsync(_mapper.Map<Genre>(context.Message));

            _logger.LogInformation($"The genre with {context.Message.Id} id was successfully deleted");
        }
    }
}
