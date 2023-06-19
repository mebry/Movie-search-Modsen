using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmCollection.BusinessLogic.Exceptions.AlreadyExistsException
{
    public class BaseFilmInfoAlreadyExistsException : AlreadyExistsException
    {
        public BaseFilmInfoAlreadyExistsException()
            :base("Such film already exists")
        { }
    }
}
