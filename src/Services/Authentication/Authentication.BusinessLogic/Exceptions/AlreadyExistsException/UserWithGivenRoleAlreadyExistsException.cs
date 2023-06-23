using SharedExceptions = Shared.Exceptions;

namespace Authentication.BusinessLogic.Exceptions.AlreadyExistsException
{
    public class UserWithGivenRoleAlreadyExistsException : SharedExceptions.AlreadyExistsException
    {
        public UserWithGivenRoleAlreadyExistsException() 
            : base("User already have this role") { }
    }
}
