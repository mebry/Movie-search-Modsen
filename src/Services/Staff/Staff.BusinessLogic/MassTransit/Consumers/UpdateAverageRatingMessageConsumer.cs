using MassTransit;
using Microsoft.Extensions.Logging;
using Shared.Messages;
using Staff.DataAccess.Entities;
using Staff.DataAccess.Repositories.Interfaces;

namespace Staff.BusinessLogic.MassTransit.Consumers
{
    public class UpdateAverageRatingMessageConsumer : IConsumer<UpdateAverageRatingMessage>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<UpdateAverageRatingMessageConsumer> _logger;

        public UpdateAverageRatingMessageConsumer(IUnitOfWork unitOfWork, ILogger<UpdateAverageRatingMessageConsumer> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task Consume(ConsumeContext<UpdateAverageRatingMessage> context)
        {
            var film = new Film
            {
                Id = context.Message.FilmId,
                AverageRating = context.Message.AverageRating
            };

            _unitOfWork.FilmRepository.Update(film);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
