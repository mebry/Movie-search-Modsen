using Mapster;
using Rating.BusinessLogic.DTOs;
using Rating.DataAccess.Entities;
using Shared.Enums;
using Shared.Messages.RatingMessages;

namespace Rating.BusinessLogic.Mappings
{
    public class AverageRatingMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<Film, UpdateAverageRatingMessage>()
                .Map(dest => dest.FilmId, src => src.Id);

            config.NewConfig<FilmDTO, UpdateAverageRatingMessage>()
                .Map(dest => dest.FilmId, src => src.Id);
        }
    }
}
