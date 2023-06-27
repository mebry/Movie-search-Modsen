using Mapster;
using MassTransit;
using Microsoft.Extensions.Logging;
using Shared.Messages.FilmMessages;
using Staff.DataAccess.Entities;
using Staff.DataAccess.Repositories.Interfaces;

namespace Staff.BusinessLogic.MassTransit.Consumers
{
    public class CreatedFilmMessageConsumer : IConsumer<CreatedFilmMessage>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<CreatedFilmMessageConsumer> _logger;

        public CreatedFilmMessageConsumer(IUnitOfWork unitOfWork, ILogger<CreatedFilmMessageConsumer> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task Consume(ConsumeContext<CreatedFilmMessage> context)
        {
            var film = new Film
            {
                Id = context.Message.Id,
                Title = context.Message.Title,
                ReleaseDate = Convert.ToDateTime(context.Message.ReleaseDate),
                AverageRating = 0,
                CountOfScores = 0
            };

            await _unitOfWork.FilmRepository.CreateAsync(film);
            await _unitOfWork.SaveChangesAsync();

            _logger.LogInformation($"Film {film.Id} has been successfully created");
        }
    }
}
