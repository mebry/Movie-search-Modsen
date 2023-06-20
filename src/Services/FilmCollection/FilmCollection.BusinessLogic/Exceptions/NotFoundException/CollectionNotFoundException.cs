using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedExceptions = Shared.Exceptions;

namespace FilmCollection.BusinessLogic.Exceptions.NotFoundException
{
    public class CollectionNotFoundException : SharedExceptions.NotFoundException
    {
        public CollectionNotFoundException(Guid id) 
            : base($"Collection with ${id} id doesn't exists") 
        {
        
        }
    }
}
