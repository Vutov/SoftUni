namespace Theatre.Exceptions
{
    using System;

    public class TimeDurationOverlapException : ApplicationException
    {
        public TimeDurationOverlapException(string msg)
            : base(msg)
        {  
        }
    }
}
