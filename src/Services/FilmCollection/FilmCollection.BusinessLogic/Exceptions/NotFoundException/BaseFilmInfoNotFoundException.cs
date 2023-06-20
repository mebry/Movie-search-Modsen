using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedExceptions = Shared.Exceptions;

namespace FilmCollection.BusinessLogic.Exceptions.NotFoundException
{
    public class BaseFilmInfoNotFoundException : SharedExceptions.NotFoundException
    {
        public BaseFilmInfoNotFoundException(Guid id)
            :base($"Information about film with ${id} id doesn't exists")
        {
            
        }
    }
}
