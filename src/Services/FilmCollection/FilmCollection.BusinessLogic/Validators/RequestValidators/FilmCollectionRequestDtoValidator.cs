using FilmCollection.BusinessLogic.DTOs.RequestDTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmCollection.BusinessLogic.Validators.RequestValidators
{
    public class FilmCollectionRequestDtoValidator : AbstractValidator<FilmCollectionRequestDto>
    {
        public FilmCollectionRequestDtoValidator() 
        {
            RuleFor(fc => fc.CollectionId)
                .NotNull()
                .NotEmpty()
                .WithMessage("Collection id is required");

            RuleFor(fc => fc.BaseFilmInfoId)
                .NotNull()
                .NotEmpty()
                .WithMessage("Film id is required");
        }
    }
}
