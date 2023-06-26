using FilmCollection.DataAccess.Repositories.Interfaces;
using MassTransit;
using Shared.Messages.RatingMessages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmCollection.BusinessLogic.MassTransit.Consumers.RatingConsumers
{
    internal class UpdateCountOfScoresConsumerMessageConsumer :
        IConsumer<UpdateCountOfScoresMessage>
    {
        private readonly IBaseFilmInfoRepository _baseFilmInfoRepository;

        public UpdateCountOfScoresConsumerMessageConsumer(IBaseFilmInfoRepository baseFilmInfoRepository)
        {
            _baseFilmInfoRepository = baseFilmInfoRepository;
        }   

        public async Task Consume(ConsumeContext<UpdateCountOfScoresMessage> context)
        {
            var baseFilmInfoToUpdate = await _baseFilmInfoRepository.GetBaseFilmInfoByIdAsync(context.Message.FilmId, true);

            baseFilmInfoToUpdate.NumberOfRatings = context.Message.CountOfScores;

            await _baseFilmInfoRepository.UpdateBaseFilmInfoAsync(baseFilmInfoToUpdate);
        }
    }
}
