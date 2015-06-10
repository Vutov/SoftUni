namespace MassEffect.Exceptions
{
    public class LocationOutOfRangeException : ShipException
    {
        public LocationOutOfRangeException(string msg)
            : base(msg)
        {
        }
    }
}
