namespace WinterIsComing.Core
{
    using System;
    using Contracts;
    using Models;
    using Models.Units;

    public static class UnitFactory
    {
        public static IUnit Create(UnitType type, string name, int x, int y)
        {
            switch (type)
            {
                case UnitType.Warrior:
                    var warrior = new Warrior(x, y, name);
                    return warrior;
                case UnitType.IceGiant:
                    var iceGiant = new IceGiant(x, y, name);
                    return iceGiant;
                case UnitType.Mage:
                    var mage = new Mage(x, y, name);
                    return mage;
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
