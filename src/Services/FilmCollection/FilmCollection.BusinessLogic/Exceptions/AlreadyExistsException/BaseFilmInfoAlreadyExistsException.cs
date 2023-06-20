using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedExceptions = Shared.Exceptions;

namespace FilmCollection.BusinessLogic.Exceptions.AlreadyExistsException
{
    public class BaseFilmInfoAlreadyExistsException : SharedExceptions.AlreadyExistsException
    {
        public BaseFilmInfoAlreadyExistsException()
            :base("Such film already exists")
        { }
    }
}
