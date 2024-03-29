﻿using FilmCollection.BusinessLogic.DTOs.RequestDTOs;
using FilmCollection.BusinessLogic.DTOs.ResponseDTOs;
using Shared.Enums;

namespace FilmCollection.BusinessLogic.Services.Interfaces
{
    public interface IFilmCountryService
    {
        Task<FilmCountryResponseDto> CreateFilmCountry(FilmCountryRequestDto filmCountryRequest);
        Task DeleteFilmCountry(Guid filmId, Countries countryId);
        Task<FilmCountryResponseDto> GetFilmCountryAsync(Guid filmId, Countries countryId);
    }
}
