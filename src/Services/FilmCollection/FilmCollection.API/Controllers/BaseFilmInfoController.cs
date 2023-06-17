using FilmCollection.API.Extensions;
using FilmCollection.BusinessLogic.DTOs.RequestDTOs;
using FilmCollection.BusinessLogic.Services.Interfaces;
using FluentValidation;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace FilmCollection.API.Controllers
{
    [Route("api/v1/films")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "v1")]
    public class BaseFilmInfoController : ControllerBase
    {
        private readonly IBaseFilmInfoService _baseFilmInfoService;
        private readonly IValidator<BaseFilmInfoRequestDto> _validator;
        private readonly ILogger _logger;

        public BaseFilmInfoController(IBaseFilmInfoService baseFilmInfoService, IValidator<BaseFilmInfoRequestDto> validator, ILogger logger)
        {
            _baseFilmInfoService = baseFilmInfoService;
            _validator = validator;
            _logger = logger;
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
            {
                result.AddToModelState(ModelState);
                _logger.LogError("Invalid data was provided when trying to create base information about film");
                return BadRequest(modelState:ModelState);
            }
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

        [HttpPut("{filmdId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        [ProducesResponseType(409)]
        public async Task<IActionResult> UpdateFilmInfoAsync(Guid filmId, BaseFilmInfoRequestDto baseFilmInfoRequestDto)
        {
            await _baseFilmInfoService.UpdateBaseFilmInfoAsync(filmId, baseFilmInfoRequestDto);
            return NoContent();
        }
    }
}
