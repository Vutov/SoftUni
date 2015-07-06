namespace WinterIsComing.Core
{
    using System.Collections.Generic;
    using System.Linq;
    using Contracts;

    class UnitEfector: IUnitEffector
    {
        private const int EfectorHealth = 50;

        public void ApplyEffect(IEnumerable<IUnit> units)
        {
            units.ToList().ForEach(u => u.HealthPoints += EfectorHealth);
        }
    }
}
