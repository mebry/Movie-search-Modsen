using Film.BusinessLogic.DTOs.ResponseDTOs;
using Film.DataAccess.Entities;
using Mapster;
using Shared.Enums;
using Shared.Extensions;

namespace Film.BusinessLogic.Mappings
{
    public class FilmMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<Countries, CountryResponseDTO>()
                .Map(dest => dest.Name, src => src.GetDescription())
                .Map(dest => dest.Id, src => src);

            config.NewConfig<FilmModel, FilmResponseDTO>()
                .Map(dest => dest.Genres, src => src.FilmGenres.Select(fg => fg.Genre).ToList())
                .Map(dest => dest.Tags, src => src.FilmTags.Select(fg => fg.Tag).ToList())
                .Map(dest => dest.Countries, src => src.FilmCountries.Select(fm => fm.CountryId))
                .Map(dest => dest.StaffPersons, src => src.StaffPersonPositions.Select(spp => spp.StaffPerson));

            config.NewConfig<StaffPerson, StaffPersonResponseDTO>()
                .Map(dest => dest.Positions, src => src.StaffPersonPositions.Select(spp => spp.Position));
        }
    }
}
