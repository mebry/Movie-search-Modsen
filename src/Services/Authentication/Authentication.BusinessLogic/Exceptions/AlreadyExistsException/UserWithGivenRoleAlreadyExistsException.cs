using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.BusinessLogic.Exceptions.AlreadyExistsException
{
    public class UserWithGivenRoleAlreadyExistsException : AlreadyExistsException
    {
        public UserWithGivenRoleAlreadyExistsException() 
            : base("User already have this role") { }
    }
}
