namespace WinterIsComing.Contracts
{
    using System.Collections.Generic;

    /// <summary>
    /// Combat handler for the battles.
    /// </summary>
    public interface ICombatHandler
    {
        /// <summary>
        /// Gets or sets the unit for that has to be handled.
        /// </summary>
        IUnit Unit { get; set; }

        /// <summary>
        /// Gets all targets for the unit based on its type and preferences.
        /// </summary>
        /// <param name="candidateTargets">IEnumerable of IUnit containing all possible targets</param>
        /// <returns>IEnumerable of IUnit containing all targets</returns>
        IEnumerable<IUnit> PickNextTargets(IEnumerable<IUnit> candidateTargets);

        /// <summary>
        /// Makes the appropriate attack depending on the unit.
        /// </summary>
        /// <returns>Generated Spell</returns>
        ISpell GenerateAttack();
    }
}
