using Mapster;
using Microsoft.Extensions.DependencyInjection;
using Reporting.BusinessLogic.DTOs.ConsumerDTOs;
using Reporting.DataAccess.Entities;
using Shared.Messages.RatingMessages;

namespace Reporting.BusinessLogic.Extensions
{
    internal static class MapsterConfigurationExtensions
    {
        public static void RegisterMapsterConfiguration(this IServiceCollection services)
        {
            TypeAdapterConfig<Film, ConsumerAverageRatingDTO>
            .NewConfig()
            .Map(dest => dest.FilmId, src => src.Id);

            TypeAdapterConfig<Film, ConsumerCountOfScoresDTO>
            .NewConfig()
            .Map(dest => dest.FilmId, src => src.Id);
        }
    }
}
