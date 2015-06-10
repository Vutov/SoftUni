namespace MassEffect.Exceptions
{
    public class InsufficientFuelException : ShipException
    {
        public InsufficientFuelException(string msg)
            : base(msg)
        {
        }
    }
}
