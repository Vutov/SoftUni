namespace WinterIsComing.Contracts
{
    using System.Collections.Generic;

    /// <summary>
    /// Special effect in game.
    /// </summary>
    public interface IUnitEffector
    {
        /// <summary>
        /// Applies the effect to given units.
        /// </summary>
        /// <param name="units">IEnumerable of Units</param>
        void ApplyEffect(IEnumerable<IUnit> units);
    }
}
