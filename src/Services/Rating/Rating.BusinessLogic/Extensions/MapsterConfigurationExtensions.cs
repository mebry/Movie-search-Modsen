using Mapster;
using Microsoft.Extensions.DependencyInjection;
using Rating.BusinessLogic.DTOs;
using Shared.Messages;

namespace Rating.BusinessLogic.Extensions
{
    internal static class MapsterConfigurationExtensions
    {
        public static void RegisterMapsterConfiguration(this IServiceCollection services)
        {
            TypeAdapterConfig<FilmDTO, UpdateAverageRatingMessage>
            .NewConfig()
            .Map(dest => dest.FilmId, src => src.Id);

            TypeAdapterConfig<FilmDTO, UpdateCountOfScoresMessage>
            .NewConfig()
            .Map(dest => dest.FilmId, src => src.Id);
        }
    }
}
