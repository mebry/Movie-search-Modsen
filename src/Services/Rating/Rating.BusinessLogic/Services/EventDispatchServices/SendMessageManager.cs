using Mapster;
using MassTransit;

namespace Rating.BusinessLogic.Services.EventDispatchServices
{
    internal class SendMessageManager : ISendMessageManager
    {
        private readonly IPublishEndpoint _publishEndpoint;

        public SendMessageManager(IPublishEndpoint publishEndpoint)
        {
            _publishEndpoint = publishEndpoint;
        }

        public async Task SendMessageAsync<From, To>(From message)
        {
            var sendMessage = message!.Adapt<To>();

            await _publishEndpoint.Publish(sendMessage!);
        }
    }
}
