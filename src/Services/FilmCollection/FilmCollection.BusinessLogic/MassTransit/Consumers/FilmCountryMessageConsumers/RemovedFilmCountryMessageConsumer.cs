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
    internal class RemovedFilmCountryMessageConsumer : IConsumer<RemovedFilmCountryMessage>
    {
        private readonly IMapper _mapper;
        private readonly IFilmCountryRepository _filmCountryRepository;
        private readonly ILogger<RemovedFilmCountryMessageConsumer> _logger;

        public RemovedFilmCountryMessageConsumer(IMapper mapper, IFilmCountryRepository filmCountryRepository, ILogger<RemovedFilmCountryMessageConsumer> logger)
        {
            _mapper = mapper;
            _filmCountryRepository = filmCountryRepository;
            _logger = logger;
        }

        public async Task Consume(ConsumeContext<RemovedFilmCountryMessage> context)
        {
            await _filmCountryRepository.DeleteFilmCountryAsync(_mapper.Map<FilmCountry>(context.Message));

            _logger.LogInformation($"Film country association with {context.Message.FilmId} film id and {context.Message.CountryId} country id was successfully deleted");
        }
    }
}
