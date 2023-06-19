using FilmCollection.BusinessLogic.DTOs.RequestDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FilmCollection.BusinessLogic.DTOs.ResponseDTOs;

namespace FilmCollection.BusinessLogic.Services.Interfaces
{
    public interface IFilmCollectionService
    {
        Task<FilmCollectionResponseDto> CreateFilmCollectionAssociationAsync(FilmCollectionRequestDto filmCollectionRequestDto);
        Task DeleteFilmCollectionAssociationAsync(Guid collectionId, Guid filmId);
        Task<FilmCollectionResponseDto> GetFilmCollectionAsscoationAsync(Guid collectionId, Guid filmId);
    }
}
