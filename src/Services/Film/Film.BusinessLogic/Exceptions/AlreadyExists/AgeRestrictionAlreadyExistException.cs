namespace Film.BusinessLogic.Exceptions.AlreadyExists
{
    /// <summary>
    /// Represents an exception that is thrown when an age restriction already exists.
    /// </summary>
    public class AgeRestrictionAlreadyExistsException : AlreadyExistsException
    {
        public AgeRestrictionAlreadyExistsException()
            : base("The age restriction already exists") { }
    }
}
