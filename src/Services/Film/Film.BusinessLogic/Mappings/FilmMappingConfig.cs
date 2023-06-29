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
                .Map(dest => dest.StaffPersons,src => src.StaffPersonPositions
                    .GroupBy(sp => sp.StaffPersonId)
                    .Select(group => new StaffPersonResponseDTO
                    {
                        Id = group.Key,
                        Name = group.First().StaffPerson.Name,
                        Surname = group.First().StaffPerson.Surname,
                        ImageUrl = group.First().StaffPerson.ImageUrl,
                        Positions = group.Select(sp => new PositionResponseDTO
                        {
                            Id = sp.PositionId,
                            Name = sp.Position.Name
                        }).ToList()
                    }));
        }
    }
}
