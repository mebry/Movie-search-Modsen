using SharedExceptions = Shared.Exceptions;

namespace Authentication.BusinessLogic.Exceptions.NotFoundException
{
    internal class RoleNotFoundException : SharedExceptions.NotFoundException
    {
        public RoleNotFoundException() : base("Such role doesn't exists")
        {

        }
    }
}
