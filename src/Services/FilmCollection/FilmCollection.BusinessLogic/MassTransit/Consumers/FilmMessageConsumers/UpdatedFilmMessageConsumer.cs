﻿using FilmCollection.DataAccess.Models;
using FilmCollection.DataAccess.Repositories.Interfaces;
using MapsterMapper;
using MassTransit;
using Microsoft.Extensions.Logging;
using Shared.Messages.FilmMessages;

namespace FilmCollection.BusinessLogic.MassTransit.Consumers.FilmMessageConsumers
{
    public class UpdatedFilmMessageConsumer : IConsumer<UpdatedFilmMessage>
    {
        private readonly IBaseFilmInfoRepository _baseFilmInfoRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<UpdatedFilmMessageConsumer> _logger;

        public UpdatedFilmMessageConsumer(IBaseFilmInfoRepository baseFilmInfoRepository, IMapper mapper, ILogger<UpdatedFilmMessageConsumer> logger)
        {
            _baseFilmInfoRepository = baseFilmInfoRepository;
            _mapper = mapper;   
            _logger = logger;
        }

        public async Task Consume(ConsumeContext<UpdatedFilmMessage> context)
        {
            var existingObject = await _baseFilmInfoRepository.GetBaseFilmInfoByIdAsync(context.Message.Id, true);

            var objectToUpdate = _mapper.Map<UpdatedFilmMessage, BaseFilmInfo>(context.Message, existingObject);

            await _baseFilmInfoRepository.UpdateBaseFilmInfoAsync(objectToUpdate);

            _logger.LogInformation($"Base film info with {context.Message.Id} was successfully updated");
        }
    }
}
