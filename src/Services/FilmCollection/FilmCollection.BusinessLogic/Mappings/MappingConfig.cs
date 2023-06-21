using FilmCollection.BusinessLogic.DTOs.ResponseDTOs;
using FilmCollection.DataAccess.Models;
using Mapster;

namespace FilmCollection.BusinessLogic.Mappings
{
    internal class MappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config) 
        {
            config.NewConfig<BaseFilmInfo, BaseFilmInfoResponseDto>()
                .Map(dest => dest.Genres, src => src.FilmGenres.Select(fg => fg.Genre).ToList())
                .Map(dest => dest.Countries, src => src.FilmCountries.Select(fm => fm.CountryId));
        }  
    }
}
