using Film.BusinessLogic.DTOs.ResponseDTOs;
using Film.DataAccess.Entities;
using Mapster;
using Shared.Enums;
using Shared.Extensions;
using Shared.Messages.StaffMessages;

namespace Film.BusinessLogic.Mappings
{
    public class StaffPersonMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<CreatedStaffPersonMessage, StaffPerson>()
                .Map(dest => dest.ImageUrl, src => src.ImgUrl);

            config.NewConfig<UpdateStaffPersonMessage, StaffPerson>()
                .Map(dest => dest.ImageUrl, src => src.ImgUrl);
        }
    }
}
