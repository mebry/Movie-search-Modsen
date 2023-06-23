using SharedExceptions = Shared.Exceptions;

namespace Authentication.BusinessLogic.Exceptions.NotFoundException
{
    public class UserNotFoundException : SharedExceptions.NotFoundException
    {
        public UserNotFoundException() 
            : base("Such user doesn't exists")
        {

        }
    }
}
