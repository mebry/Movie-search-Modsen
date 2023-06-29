using Mapster;
using Rating.BusinessLogic.DTOs;
using Rating.DataAccess.Entities;
using Shared.Messages.RatingMessages;

namespace Rating.BusinessLogic.Mappings
{
    public class CountOfScoresMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            TypeAdapterConfig<FilmDTO, UpdateCountOfScoresMessage>
            .NewConfig()
            .Map(dest => dest.FilmId, src => src.Id);

            TypeAdapterConfig<Film, UpdateCountOfScoresMessage>
            .NewConfig()
            .Map(dest => dest.FilmId, src => src.Id);
        }
    }
}
