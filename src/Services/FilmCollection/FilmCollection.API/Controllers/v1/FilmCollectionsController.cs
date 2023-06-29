using FilmCollection.BusinessLogic.DTOs.RequestDTOs;
using FilmCollection.BusinessLogic.Services.Interfaces;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace FilmCollection.API.Controllers.v1
{
    public class FilmCollectionsController : BaseApiController
    {
        private readonly IFilmCollectionService _filmCollectionService;
        private readonly IValidator<FilmCollectionRequestDto> _validator;

        public FilmCollectionsController(
            ILogger<BaseApiController> logger,
            IFilmCollectionService filmCollectionService,
            IValidator<FilmCollectionRequestDto> validator
            )
            : base(logger)
        {
            _filmCollectionService = filmCollectionService;
            _validator = validator;
        }

        [HttpGet("{collectionId}/{filmId}", Name = "GetFilmCollectionById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetFilmCollectionAssociationAsync(Guid filmId, Guid collectionId)
        {
            var associationToReturn = await _filmCollectionService.GetFilmCollectionAsscoationAsync(filmId, collectionId);
            return Ok(associationToReturn);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<IActionResult> CreateFilmCollectionAsync(FilmCollectionRequestDto filmCollectionRequest)
        {
            var result = await _validator.ValidateAsync(filmCollectionRequest);
            if (!result.IsValid)
                ProcessInvalidValidationResult(result, "Invalid data was provided when trying to create a FilmCollection association");
            var createdFilmCollection = await _filmCollectionService.CreateFilmCollectionAssociationAsync(filmCollectionRequest);
            return CreatedAtRoute("GetFilmCollectionById", new {filmId = createdFilmCollection.BaseFilmInfoId, collectionId = createdFilmCollection.CollectionModelId}, createdFilmCollection);
        }

        [HttpDelete("{collectionId}/{filmId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteFilmCollectionAsync(Guid collectionId, Guid filmId)
        {
            await _filmCollectionService.DeleteFilmCollectionAssociationAsync(collectionId, filmId);
            return NoContent();
        }
        

    }
}
