using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmCollection.BusinessLogic.Exceptions.AlreadyExistsException
{
    internal class CollectionAlreadyExistsException : AlreadyExistsException
    {
        public CollectionAlreadyExistsException() 
            : base("Such collection already exists")
        {
        }
    }
}
