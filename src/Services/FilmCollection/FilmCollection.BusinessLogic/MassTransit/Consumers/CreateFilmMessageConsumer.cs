using FilmCollection.DataAccess.Models;
using FilmCollection.DataAccess.Repositories.Interfaces;
using MassTransit;
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

        public CreateFilmMessageConsumer(IBaseFilmInfoRepository filmInfoRepository)
        {
            _filmInfoRepository = filmInfoRepository;
        }

        public async Task Consume(ConsumeContext<CreatedFilmMessage> context)
        {
            var newFilmInfoToAdd = new BaseFilmInfo()
            {
                Title = context.Message.Title,
                ReleaseDate = context.Message.ReleaseDate,
                Duration = context.Message.Duration,
                PosterURL = context.Message.PosterURL,
                AverageRating = 0,
                NumberOfRatings = 0
            };

            await _filmInfoRepository.AddBaseFilmInfoAsync(newFilmInfoToAdd);
        }
    }
}
