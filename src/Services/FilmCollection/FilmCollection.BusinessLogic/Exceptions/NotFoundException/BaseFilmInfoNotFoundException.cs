using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmCollection.BusinessLogic.Exceptions.NotFoundException
{
    public class BaseFilmInfoNotFoundException : NotFoundException
    {
        public BaseFilmInfoNotFoundException(Guid id)
            :base($"Information about film with ${id} id doesn't exists")
        {
            
        }
    }
}
