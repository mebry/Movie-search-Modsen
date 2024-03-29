﻿namespace Shared.Exceptions
{
    /// <summary>
    /// Represents an exception that is thrown when an age restriction already exists.
    /// </summary>
    public class AlreadyExistsException : Exception
    {
        public AlreadyExistsException(string message)
            : base(message) { }
    }
}
