using FilmCollection.BusinessLogic.DTOs.RequestDTOs;
using FilmCollection.BusinessLogic.Services.Interfaces;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Shared.Enums;

namespace FilmCollection.API.Controllers.v1
{
    public class FIlmCountriesController : BaseApiController
    {
        private readonly IFilmCountryService _filmCountryService;
        private readonly IValidator<FilmCountryRequestDto> _validator;

        public FIlmCountriesController(IFilmCountryService filmCountryService, IValidator<FilmCountryRequestDto> validator, ILogger<BaseApiController> logger)
            : base(logger)
        {
            _filmCountryService = filmCountryService;
            _validator = validator;
        }

        [HttpGet("{countryId}/{filmId}", Name = "GetFilmCountryById")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetFilmCountryAssociationAsync(Guid filmId, Countries countryId)
        {
            var associationToReturn = await _filmCountryService.GetFilmCountryAsync(filmId, countryId);
            return Ok(associationToReturn);
        }


        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(409)]
        public async Task<IActionResult> CreateFilmCountryAsync(FilmCountryRequestDto filmCountryRequest)
        {
            var result = await _validator.ValidateAsync(filmCountryRequest);
            if(!result.IsValid)
                ProcessInvalidValidationResult(result, "Invalid data was provided when trying to create a FilmCountry association");
            var createdFilmCountry = await _filmCountryService.CreateFilmCountry(filmCountryRequest);
            return CreatedAtRoute("GetFilmCountryById", new { filmId = createdFilmCountry.BaseFilmInfoId, countryId = createdFilmCountry.CountryId }, createdFilmCountry);
        }

        [HttpDelete("{filmId}/{countryId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> DeleteFilmContryAsync(Guid filmId, Countries countryId)
        {
            await _filmCountryService.DeleteFilmCountry(filmId, countryId);
            return NoContent();
        }

    }
}
