namespace WinterIsComing.Contracts
{
    /// <summary>
    /// Game unit.
    /// </summary>
    public interface IUnit
    {
        /// <summary>
        /// Gets or sets units X.
        /// </summary>
        int X { get; set; }

        /// <summary>
        /// Gets or sets units Y.
        /// </summary>
        int Y { get; set; }

        /// <summary>
        /// Gets units Name.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Gets units Range.
        /// </summary>
        int Range { get; }

        /// <summary>
        /// Gets or sets units attack points.
        /// </summary>
        int AttackPoints { get; set; }

        /// <summary>
        /// Gets or sets units health points.
        /// </summary>
        int HealthPoints { get; set; }

        /// <summary>
        /// Gets or sets units defense points.
        /// </summary>
        int DefensePoints { get; set; }

        /// <summary>
        /// Gets or sets units energy points.
        /// </summary>
        int EnergyPoints { get; set; }

        /// <summary>
        /// Gets units combat handler.
        /// </summary>
        ICombatHandler CombatHandler { get; }
    }
}
