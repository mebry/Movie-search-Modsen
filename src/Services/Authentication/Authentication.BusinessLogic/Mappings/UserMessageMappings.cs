using Authentication.BusinessLogic.DTOs.RequestDTOs;
using DataAccess.Models;
using Mapster;
using Shared.Messages.AuthenticationMessages;

namespace Authentication.BusinessLogic.Mappings
{
    public class UserMessageMappings : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<User, CreateUserMessage>()
                 .Map(dest => dest.Username, src => src.UserName)
                 .Map(dest => dest.Id, src => new Guid(src.Id));

            config.NewConfig<User, DeleteUserMessage>()
                 .Map(dest => dest.Id, src => new Guid(src.Id));

        }
    }
}
