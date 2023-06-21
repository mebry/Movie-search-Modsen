using FilmCollection.BusinessLogic.DTOs.RequestDTOs;
using FilmCollection.BusinessLogic.DTOs.ResponseDTOs;
using FilmCollection.DataAccess.Models;
using Mapster;
using Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
