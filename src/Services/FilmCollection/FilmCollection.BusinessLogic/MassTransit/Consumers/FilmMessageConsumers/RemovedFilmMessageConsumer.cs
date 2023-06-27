using FilmCollection.DataAccess.Models;
using FilmCollection.DataAccess.Repositories.Interfaces;
using MapsterMapper;
using MassTransit;
using Microsoft.Extensions.Logging;
using Shared.Messages.FilmMessages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmCollection.BusinessLogic.MassTransit.Consumers.FilmMessageConsumers
{
    public class RemovedFilmMessageConsumer : IConsumer<RemovedFilmMessage>
    {
        private IBaseFilmInfoRepository _baseFilmInfoRepository;
        private IMapper _mapper;
        private readonly ILogger<RemovedFilmMessageConsumer> _logger;

        public RemovedFilmMessageConsumer(IMapper mapper, IBaseFilmInfoRepository baseFilmInfoRepository, ILogger<RemovedFilmMessageConsumer> logger)
        {
            _baseFilmInfoRepository = baseFilmInfoRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task Consume(ConsumeContext<RemovedFilmMessage> context)
        {
            await _baseFilmInfoRepository.DeleteBaseFilmInfoAsync(_mapper.Map<BaseFilmInfo>(context.Message));

            _logger.LogInformation($"Base film info with {context.Message.Id} was successfully deleted");
        }
    }
}
