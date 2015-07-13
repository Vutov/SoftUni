namespace WinterIsComing.Core.Exceptions
{
    public class InvalidPositionException : GameException
    {
        public InvalidPositionException(string msg) 
            : base(msg)
        {
        }
    }
}
