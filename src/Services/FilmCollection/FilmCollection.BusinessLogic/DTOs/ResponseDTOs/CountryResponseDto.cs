using Shared.Enums;

namespace FilmCollection.BusinessLogic.DTOs.ResponseDTOs
{
    public class CountryResponseDto
    {
        public Countries Id { get; set; }   
        public string CountryName { get; set; }
    }
}
