using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.BusinessLogic.Exceptions.NotFoundException
{
    public class UserNotFoundException : NotFoundException
    {
        public UserNotFoundException() 
            : base("Such user doesn't exists")
        {

        }
    }
}
