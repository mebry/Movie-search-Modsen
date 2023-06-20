using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedExceptions = Shared.Exceptions;

namespace FilmCollection.BusinessLogic.Exceptions.AlreadyExistsException
{
    public class GenreAlreadyExistsException : SharedExceptions.AlreadyExistsException
    {
        public GenreAlreadyExistsException() 
            : base("This genre already exists") { }
    }
}
