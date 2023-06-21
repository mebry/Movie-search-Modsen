using MassTransit;
using Microsoft.Extensions.Logging;
using Shared.Messages;
using Staff.DataAccess.Entities;
using Staff.DataAccess.Repositories.Interfaces;

namespace Staff.BusinessLogic.MassTransit.Consumers
{
    public class UpdateCountOfScoresMessageConsumer : IConsumer<UpdateCountOfScoresMessage>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<UpdateCountOfScoresMessageConsumer> _logger;

        public UpdateCountOfScoresMessageConsumer(IUnitOfWork unitOfWork, ILogger<UpdateCountOfScoresMessageConsumer> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task Consume(ConsumeContext<UpdateCountOfScoresMessage> context)
        {
            var film = new Film
            {
                Id = context.Message.FilmId,
                CountOfScores = context.Message.CountOfScores
            };

            _unitOfWork.FilmRepository.Update(film);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
