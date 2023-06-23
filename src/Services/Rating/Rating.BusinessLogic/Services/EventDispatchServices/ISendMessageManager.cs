namespace Rating.BusinessLogic.Services.EventDispatchServices
{
    public interface ISendMessageManager
    {
        public Task SendMessageAsync<From, To>(From message);
    }
}
