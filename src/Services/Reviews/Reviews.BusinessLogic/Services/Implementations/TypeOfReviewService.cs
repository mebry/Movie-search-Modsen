using Mapster;
using Microsoft.Extensions.Logging;
using Reviews.BusinessLogic.DTOs;
using Reviews.BusinessLogic.Services.Interfaces;
using Reviews.DataAccess.Entities;
using Reviews.DataAccess.Repositories.Interfaces;

namespace Reviews.BusinessLogic.Services.Implementations
{
    public class TypeOfReviewService : ITypeOfReviewService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<TypeOfReviewService> _logger;

        public TypeOfReviewService(IUnitOfWork unitOfWork, ILogger<TypeOfReviewService> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task<ResponseTypeOfReviewDTO> CreateAsync(RequestTypeOfReviewDTO typeOfReview)
        {
            var id = Guid.NewGuid();
            var mapperTypeOfReview = typeOfReview.Adapt<TypeOfReview>();
            mapperTypeOfReview.Id = id;

            await _unitOfWork.TypeOfReviewRepository.CreateAsync(mapperTypeOfReview);
            await _unitOfWork.SaveChangesAsync();

            var resonseModel = mapperTypeOfReview.Adapt<ResponseTypeOfReviewDTO>();

            return resonseModel;
        }
    }
}
