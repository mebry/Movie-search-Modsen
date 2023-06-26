using FilmCollection.DataAccess.Models;
using FilmCollection.DataAccess.Repositories.Interfaces;
using MapsterMapper;
using MassTransit;
using Microsoft.Extensions.Logging;
using Shared.Messages.FilmCountryMessages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmCollection.BusinessLogic.MassTransit.Consumers.FilmGenreMessageConsumers
{
    internal class CreatedFilmGenreMessageConsumer : IConsumer<CreatedFilmGenreMessage>
    {
        private readonly IMapper _mapper;
        private readonly IFilmGenreRepository _filmGenreRepository;
        private readonly ILogger<CreatedFilmGenreMessageConsumer> _logger;

        public CreatedFilmGenreMessageConsumer(IMapper mapper, IFilmGenreRepository filmGenreRepository, ILogger<CreatedFilmGenreMessageConsumer> logger)
        {
            _mapper = mapper;
            _filmGenreRepository = filmGenreRepository;
            _logger = logger;
        }

        public async Task Consume(ConsumeContext<CreatedFilmGenreMessage> context)
        {
            var mappedFilmGenre = _mapper.Map<FilmGenre>(context.Message);
            await _filmGenreRepository.CreateFilmGenreAsync(mappedFilmGenre);

            _logger.LogInformation($"Film genre association with {context.Message.FilmId} film id and {context.Message.GenreId} genre id was successfully created");
        }
    }
}
