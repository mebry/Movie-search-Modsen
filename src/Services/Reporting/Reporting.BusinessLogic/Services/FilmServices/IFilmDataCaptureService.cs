﻿using Reporting.BusinessLogic.DTOs.ConsumerDTOs;

namespace Reporting.BusinessLogic.Services.FilmServices
{
    internal interface IFilmDataCaptureService
    {
        public Task CreateAsync(ConsumerFilmDTO entity);
        public Task UpdateAsync(ConsumerFilmDTO entity);
        public Task UpdateAverageRatingAsync(ConsumerAverageRatingDTO entity);
        public Task UpdateCountOfScoresAsync(ConsumerCountOfScoresDTO entity);
        public Task DeleteAsync(Guid id);
    }
}
