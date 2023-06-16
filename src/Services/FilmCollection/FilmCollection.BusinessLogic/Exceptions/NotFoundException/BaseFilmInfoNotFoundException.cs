using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmCollection.BusinessLogic.Exceptions.NotFoundException
{
    public class BaseFilmInfoNotFoundException : NotFoundException
    {
        public BaseFilmInfoNotFoundException()
            :base("Such film doesn't exists")
        {
            
        }
    }
}
