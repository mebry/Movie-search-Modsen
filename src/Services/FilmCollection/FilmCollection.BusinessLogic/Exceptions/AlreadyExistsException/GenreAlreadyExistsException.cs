using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmCollection.BusinessLogic.Exceptions.AlreadyExistsException
{
    public class GenreAlreadyExistsException : AlreadyExistsException
    {
        public GenreAlreadyExistsException() 
            : base("This genre already exists") { }
    }
}
