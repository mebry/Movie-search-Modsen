using Mapster;
using MassTransit;
using Rating.BusinessLogic.DTOs;
using Shared.Messages;

namespace Rating.BusinessLogic.Services.EventDispatchServices
{
    internal class EventDispatchService : IEventDispatchService
    {
        private readonly IPublishEndpoint _publishEndpoint;

        public EventDispatchService(IPublishEndpoint publishEndpoint)
        {
            _publishEndpoint = publishEndpoint;
        }

        public async Task SendNewAverageRatingAsync(FilmDTO film)
        {
            var message = film.Adapt<UpdateAverageRatingMessage>();

            await _publishEndpoint.Publish(message);
        }

        public async Task SendNewCountOfScoresAsync(IEnumerable<FilmDTO> film)
        {
            var message = film.Adapt<IEnumerable<UpdateCountOfScoresMessage>>();

            await _publishEndpoint.Publish(message);
        }
    }
}
