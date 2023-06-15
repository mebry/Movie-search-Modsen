namespace Film.BusinessLogic.Exceptions.AlreadyExists
{
    public class TagAlreadyExistsException : AlreadyExistsException
    {
        public TagAlreadyExistsException()
            : base("The tag already exists") { }
    }
}
