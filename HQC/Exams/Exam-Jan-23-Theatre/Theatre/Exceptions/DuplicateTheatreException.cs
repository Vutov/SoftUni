namespace Theatre.Exceptions
{
    using System;

    public class DuplicateTheatreException : ApplicationException
    {
        public DuplicateTheatreException(string msg)
            : base(msg)
        {
        }
    }
}
