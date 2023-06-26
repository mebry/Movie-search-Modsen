using FilmCollection.DataAccess.Repositories.Interfaces;
using MassTransit;
using Microsoft.Extensions.Logging;
using Shared.Messages.RatingMessages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmCollection.BusinessLogic.MassTransit.Consumers.RatingMessageConsumers
{
    internal class UpdateCountOfScoresConsumerMessageConsumer :
        IConsumer<UpdateCountOfScoresMessage>
    {
        private readonly IBaseFilmInfoRepository _baseFilmInfoRepository;
        private readonly ILogger<UpdateCountOfScoresConsumerMessageConsumer> _logger;

        public UpdateCountOfScoresConsumerMessageConsumer(IBaseFilmInfoRepository baseFilmInfoRepository, ILogger<UpdateCountOfScoresConsumerMessageConsumer> logger)
        {
            _baseFilmInfoRepository = baseFilmInfoRepository;
            _logger = logger;   
        }   

        public async Task Consume(ConsumeContext<UpdateCountOfScoresMessage> context)
        {
            var baseFilmInfoToUpdate = await _baseFilmInfoRepository.GetBaseFilmInfoByIdAsync(context.Message.FilmId, true);

            var oldValue = baseFilmInfoToUpdate.NumberOfRatings;

            baseFilmInfoToUpdate.NumberOfRatings = context.Message.CountOfScores;

            await _baseFilmInfoRepository.UpdateBaseFilmInfoAsync(baseFilmInfoToUpdate);

            _logger.LogInformation($"The number of rating in the base film info with {baseFilmInfoToUpdate.Id} id was successfully updated." +
                $"Old value was {oldValue} now its {baseFilmInfoToUpdate.NumberOfRatings}");
        }
    }
}
