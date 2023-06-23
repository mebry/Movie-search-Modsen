using FilmCollection.BusinessLogic.DTOs.RequestDTOs;
using FilmCollection.BusinessLogic.DTOs.ResponseDTOs;
using FilmCollection.BusinessLogic.Services.Interfaces;
using FilmCollection.BusinessLogic.Validators.ServiceValidators.Interfaces;
using FilmCollection.DataAccess.Models;
using FilmCollection.DataAccess.Repositories.Interfaces;
using MapsterMapper;

namespace FilmCollection.BusinessLogic.Services.Implementations
{
    internal class CollectionService : ICollectionService
    {
        private readonly IMapper _mapper;
        private readonly ICollectionRepository _collectionRepository;
        private readonly ICollectionServiceValidator _collectionServiceValidator;

        public CollectionService(IMapper mapper, ICollectionRepository collectionRepository, ICollectionServiceValidator collectionServiceValidator)
        {
            _mapper = mapper;
            _collectionRepository = collectionRepository;
            _collectionServiceValidator = collectionServiceValidator;
        }   

        public async Task<CollectionResponseDto> CreateCollectionAsync(CollectionRequestDto collectionRequestDto)
        {
            await _collectionServiceValidator.CheckIfCollectionWithGivenTitleDoesntExistsAsync(collectionRequestDto.Title);
            var mappedCollection = _mapper.Map<CollectionModel>(collectionRequestDto);
            mappedCollection.Id = new Guid();
            await _collectionRepository.CreateCollectionAsync(mappedCollection);
            return _mapper.Map<CollectionResponseDto>(mappedCollection);
        }

        public async Task DeleteCollectionAsync(Guid id)
        {
            var collectionToDelete = await _collectionServiceValidator.CheckIfCollectionExistsAndGetAsync(id,true);
            await _collectionRepository.DeleteCollectionAsync(collectionToDelete);
        }

        public async Task UpdateCollectionAsync(Guid id, CollectionRequestDto collectionRequestDto)
        {
            await _collectionServiceValidator.CheckIfCollectionExistsAsync(id);
            await _collectionServiceValidator.CheckIfCollectionWithGivenTitleDoesntExistsAsync(collectionRequestDto.Title, id);
            var mappedCollection = _mapper.Map<CollectionModel>(collectionRequestDto);
            mappedCollection.Id = id;
            await _collectionRepository.UpdateCollectionAsync(mappedCollection);
        }

        public async Task<CollectionResponseDto> GetCollectionAsync(Guid id)
        {
            var collection = await _collectionServiceValidator.CheckIfCollectionExistsAndGetAsync(id, false);
            return _mapper.Map<CollectionResponseDto>(collection);
        }

        public async Task<IEnumerable<CollectionResponseDto>> GetAllCollections()
        {
            var collections = await _collectionRepository.GetAllCollectionsAsync(false);
            return _mapper.Map<IEnumerable<CollectionResponseDto>>(collections);
        }
    }
}
