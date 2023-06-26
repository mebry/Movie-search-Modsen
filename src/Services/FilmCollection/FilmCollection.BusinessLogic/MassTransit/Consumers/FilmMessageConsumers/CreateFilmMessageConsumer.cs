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

namespace FilmCollection.BusinessLogic.MassTransit.Consumers
{
    public class CreateFilmMessageConsumer : IConsumer<CreatedFilmMessage>
    {
        private readonly IBaseFilmInfoRepository _filmInfoRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateFilmMessageConsumer> _logger;

        public CreateFilmMessageConsumer(IMapper mapper, IBaseFilmInfoRepository filmInfoRepository, ILogger<CreateFilmMessageConsumer> logger)
        {
            _filmInfoRepository = filmInfoRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task Consume(ConsumeContext<CreatedFilmMessage> context)
        {
            var mappedMessage = _mapper.Map<BaseFilmInfo>(context.Message);

            await _filmInfoRepository.AddBaseFilmInfoAsync(mappedMessage);

            _logger.LogInformation($"New base film info with {context.Message.Id} was successfully created");
            
        }
    }
}
