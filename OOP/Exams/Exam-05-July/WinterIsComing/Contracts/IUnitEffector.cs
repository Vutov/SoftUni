namespace WinterIsComing.Contracts
{
    using System.Collections.Generic;

    public interface IUnitEffector
    {
        void ApplyEffect(IEnumerable<IUnit> units);
    }
}
