using Authentication.BusinessLogic.DTOs;
using DataAccess.Models;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.BusinessLogic.Mappings
{
    public class AuthenticationMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<User, UserDto>()
                .Map(dest => dest.Username, src => src.UserName);

            config.NewConfig<UserForCreationDto, User>()
                .Map(dest => dest.UserName, src => src.Username);
        }
    }
}
