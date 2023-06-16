namespace Film.BusinessLogic.Exceptions.AlreadyExists
{
    /// <summary>
    /// Represents an exception that is thrown when an age restriction already exists.
    /// </summary>
    public class TagAlreadyExistsException : AlreadyExistsException
    {
        public TagAlreadyExistsException()
            : base("The tag already exists") { }
    }
}
