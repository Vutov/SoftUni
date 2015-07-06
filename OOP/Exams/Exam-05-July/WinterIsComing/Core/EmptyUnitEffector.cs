namespace WinterIsComing.Core
{
    using System.Collections.Generic;
    using Contracts;

    public sealed class EmptyUnitEffector : IUnitEffector
    {
        public void ApplyEffect(IEnumerable<IUnit> units)
        {
        }
    }
}
