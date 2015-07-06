namespace WinterIsComing.Core.Exceptions
{
    using System;

    public class NotEnoughEnergyException : GameException
    {
        public NotEnoughEnergyException(string msg)
            : base(msg)
        {
        }
    }
}
