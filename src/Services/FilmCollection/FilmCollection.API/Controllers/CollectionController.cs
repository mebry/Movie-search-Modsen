using FilmCollection.API.Extensions;
using FilmCollection.BusinessLogic.DTOs.RequestDTOs;
using FilmCollection.BusinessLogic.Services.Interfaces;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace FilmCollection.API.Controllers
{
    [Route("api/v1/collections")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "v1")]
    public class CollectionController : ControllerBase
    {
        private readonly ICollectionService _collectionService;
        private readonly IValidator<CollectionRequestDto> _validator;
        private readonly ILogger _logger;

        public CollectionController(ICollectionService collectionService, IValidator<CollectionRequestDto> validator, ILogger logger)
        {
            _collectionService = collectionService;
            _validator = validator;
            _logger = logger;
        }


        [HttpGet]
        [ProducesResponseType(200)]
        public async Task<IActionResult> GetAllCollectionsAsync()
        {
            var collections = await _collectionService.GetAllCollections();
            return Ok(collections);
        }

        [HttpGet("{collectionId}", Name ="CollectionById")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetCollectionAsync(Guid collectionId)
        {
            var collectionToReturn = await _collectionService.GetCollectionAsync(collectionId);
            return Ok(collectionToReturn);
        }

        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(409)]
        public async Task<IActionResult> CreateCollectionAsync(CollectionRequestDto collectionRequestDto)
        {
            var result = await _validator.ValidateAsync(collectionRequestDto);
            if (!result.IsValid)
            {
                result.AddToModelState(ModelState);
                _logger.LogError("Invalid data was provided when trying to create a collection");
                return BadRequest(modelState: ModelState);
            }
            var createdCollection = await _collectionService.CreateCollectionAsync(collectionRequestDto);
            return CreatedAtRoute("CollectionById", new { collectionId = createdCollection.Id }, createdCollection);
        }

        [HttpDelete("{collectionId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> DeleteCollectionAsync(Guid collectionId)
        {
            await _collectionService.DeleteCollectionAsync(collectionId);
            return NoContent();
        }

        [HttpPut("{collectionId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> UpdateCollectionAsync(Guid collectionId, CollectionRequestDto collectionRequestDto)
        {
            await _collectionService.UpdateCollectionAsync(collectionId, collectionRequestDto);
            return NoContent();
        }
    }
}
