using FilmCollection.BusinessLogic.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Shared.Enums;

namespace FilmCollection.API.Controllers.v1
{
    public class FIlmCountriesController : BaseApiController
    {
        private readonly IFilmCountryService _filmCountryService;

        public FIlmCountriesController(IFilmCountryService filmCountryService, ILogger<BaseApiController> logger)
            : base(logger)
        {
            _filmCountryService = filmCountryService;
        }

        [HttpGet("{countryId}/{filmId}", Name = "GetFilmCountryById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetFilmCountryAssociationAsync(Guid filmId, Countries countryId)
        {
            var associationToReturn = await _filmCountryService.GetFilmCountryAsync(filmId, countryId);
            return Ok(associationToReturn);
        }
    }
}
