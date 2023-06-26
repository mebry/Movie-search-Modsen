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

namespace FilmCollection.BusinessLogic.MassTransit.Consumers.FilmCountryMessageConsumers
{
    internal class CreatedFilmCountryMessageConsumer : IConsumer<CreatedFilmCountryMessage>
    {
        private readonly IMapper _mapper;
        private readonly IFilmCountryRepository _filmCountryRepository;
        private readonly ILogger<CreatedFilmCountryMessageConsumer> _logger;    

        public CreatedFilmCountryMessageConsumer(IMapper mapper, IFilmCountryRepository filmCountryRepository, ILogger<CreatedFilmCountryMessageConsumer> logger)
        {
            _mapper = mapper;
            _filmCountryRepository = filmCountryRepository;
            _logger = logger;
        }

        public async Task Consume(ConsumeContext<CreatedFilmCountryMessage> context)
        {
            await _filmCountryRepository.CreateFilmCountryAsync(_mapper.Map<FilmCountry>(context.Message));

            _logger.LogInformation($"Film country association with {context.Message.FilmId} film id and {context.Message.CountryId} country id was successfully created");
        }
    }
}
