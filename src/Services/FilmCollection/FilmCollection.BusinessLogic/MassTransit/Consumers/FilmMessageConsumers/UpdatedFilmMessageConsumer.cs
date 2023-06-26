using FilmCollection.DataAccess.Models;
using FilmCollection.DataAccess.Repositories.Interfaces;
using MapsterMapper;
using MassTransit;
using Microsoft.Extensions.Logging;
using Shared.Messages.FilmMessages;

namespace FilmCollection.BusinessLogic.MassTransit.Consumers.FilmMessageConsumers
{
    internal class UpdatedFilmMessageConsumer : IConsumer<UpdatedFilmMessage>
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
            await _baseFilmInfoRepository.UpdateBaseFilmInfoAsync(_mapper.Map<BaseFilmInfo>(context.Message));

            _logger.LogInformation($"Base film info with {context.Message.Id} was successfully updated");
        }
    }
}
