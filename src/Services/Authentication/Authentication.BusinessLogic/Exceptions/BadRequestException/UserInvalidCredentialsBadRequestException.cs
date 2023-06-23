using SharedExceptions = Shared.Exceptions;

namespace Authentication.BusinessLogic.Exceptions.BadRequestException
{
    public class UserInvalidCredentialsBadRequestException : SharedExceptions.BadRequestException
    {
        public UserInvalidCredentialsBadRequestException(string message) 
            : base(message) { }
    }
}
