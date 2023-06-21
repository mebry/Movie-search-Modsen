using FilmCollection.BusinessLogic.DTOs.ResponseDTOs;
using FilmCollection.DataAccess.Models;
using Mapster;
using Shared.Enums;
using Shared.Extensions;

namespace FilmCollection.BusinessLogic.Mappings
{
    internal class MappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config) 
        {
            config.NewConfig<Countries, CountryResponseDto>()
                .Map(dest => dest.CountryName, src => src.GetDescription())
                .Map(dest => dest.Id, src => src);

            config.NewConfig<BaseFilmInfo, BaseFilmInfoResponseDto>()
                .Map(dest => dest.Genres, src => src.FilmGenres.Select(fg => fg.Genre).ToList())
                .Map(dest => dest.Countries, src => src.FilmCountries.Select(fm => fm.CountryId));
        }  
    }
}
