namespace Theatre.Exceptions
{
    using System;

    public class TheatreNotFoundException : ApplicationException
    {
        public TheatreNotFoundException(string msg)
            : base(msg)
        {
        }
    }
}
