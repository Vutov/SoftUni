namespace WinterIsComing.Core.Exceptions
{
    using System;

    public class GameException : Exception
    {
        public GameException(string msg)
            : base(msg)
        {
        }
    }
}
