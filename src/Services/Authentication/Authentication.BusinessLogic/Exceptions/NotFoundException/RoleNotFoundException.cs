using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.BusinessLogic.Exceptions.NotFoundException
{
    internal class RoleNotFoundException : NotFoundException
    {
        public RoleNotFoundException() : base("Such role doesn't exists")
        {

        }
    }
}
