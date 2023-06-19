using FilmCollection.API.Extensions;
using FilmCollection.BusinessLogic.DTOs.RequestDTOs;
using FilmCollection.BusinessLogic.Services.Interfaces;
using FluentValidation;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace FilmCollection.API.Controllers.v1
{
    public class BaseFilmInfosController : BaseApiController
    {
        private readonly IBaseFilmInfoService _baseFilmInfoService;
        private readonly IValidator<BaseFilmInfoRequestDto> _validator;

        public BaseFilmInfosController(IBaseFilmInfoService baseFilmInfoService, IValidator<BaseFilmInfoRequestDto> validator, ILogger<BaseApiController> logger)
            : base(logger)
        {
            _baseFilmInfoService = baseFilmInfoService;
            _validator = validator;
        }

        [HttpGet]
        [ProducesResponseType(200)]
        public async Task<IActionResult> GetAllFilmInfosAsync()
        {
            var baseFilmInfosToReturn = await _baseFilmInfoService.GetAllBaseFilmInfosAsync();
            return Ok(baseFilmInfosToReturn);
        }

        [HttpGet("{filmId}", Name = "FilmById")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetFilmInfoAsync(Guid filmId)
        {
            var baseFilmInfoToReturn = await _baseFilmInfoService.GetBaseFilmInfoAsync(filmId);
            return Ok(baseFilmInfoToReturn);
        }

        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(409)]
        public async Task<IActionResult> CreateFilmInfo(BaseFilmInfoRequestDto baseFilmInfoRequestDto)
        {
            var result = await _validator.ValidateAsync(baseFilmInfoRequestDto);
            if (!result.IsValid)
                ProcessInvalidValidationResult(result, "Invalid data was provided when trying to create base information about film");
            var createdBaseFilmInfo = await _baseFilmInfoService.CreateBaseFilmInfoAsync(baseFilmInfoRequestDto);
            return CreatedAtRoute("FilmById", new { filmId = createdBaseFilmInfo.Id }, createdBaseFilmInfo);
        }

        [HttpDelete("{filmId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> DeleteFilmInfoAsync(Guid filmId)
        {
            await _baseFilmInfoService.DeleteBaseFilInfoAsync(filmId);
            return NoContent();
        }

        [HttpPut("{filmId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        [ProducesResponseType(409)]
        public async Task<IActionResult> UpdateFilmInfoAsync(Guid filmId, BaseFilmInfoRequestDto baseFilmInfoRequestDto)
        {
            var result = await _validator.ValidateAsync(baseFilmInfoRequestDto);
            if (!result.IsValid)
                ProcessInvalidValidationResult(result, "Invalid data was provided when trying to update base information about film");
            await _baseFilmInfoService.UpdateBaseFilmInfoAsync(filmId, baseFilmInfoRequestDto);
            return NoContent();
        }
    }
}
