﻿using FilmCollection.BusinessLogic.DTOs.RequestDTOs;
using FilmCollection.BusinessLogic.DTOs.ResponseDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmCollection.BusinessLogic.Services.Interfaces
{
    public interface ICollectionService
    {
        Task<CollectionResponseDto> CreateCollectionAsync(CollectionRequestDto collectionRequestDto);
    }
}
