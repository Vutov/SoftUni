namespace WinterIsComing.Contracts
{
    /// <summary>
    /// Game spell.
    /// </summary>
    public interface ISpell
    {
        /// <summary>
        /// Gets spell's damage.
        /// </summary>
        int Damage { get; }

        /// <summary>
        /// Gets spell's energy cost.
        /// </summary>
        int EnergyCost { get; }
    }
}
