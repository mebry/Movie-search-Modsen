namespace Film.BusinessLogic.Exceptions.AlreadyExists
{
    public class AgeRestrictionAlreadyExistsException : AlreadyExistsException
    {
        public AgeRestrictionAlreadyExistsException()
            : base("The age restriction already exists") { }
    }
}
