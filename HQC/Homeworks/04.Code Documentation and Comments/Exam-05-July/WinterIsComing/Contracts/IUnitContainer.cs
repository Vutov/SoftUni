namespace WinterIsComing.Contracts
{
    using System.Collections.Generic;

    /// <summary>
    /// Container for units.
    /// </summary>
    public interface IUnitContainer
    {
        /// <summary>
        /// Returns all units in given range.
        /// </summary>
        /// <param name="x">Starting x</param>
        /// <param name="y">Starting y</param>
        /// <param name="range">Range from x and y</param>
        /// <returns>IEnumerable of IUnits</returns>
        IEnumerable<IUnit> GetUnitsInRange(int x, int y, int range);

        /// <summary>
        /// Adds unit to the container.
        /// </summary>
        /// <param name="unit">Given Unit</param>
        void Add(IUnit unit);

        /// <summary>
        /// Removes unit from the container
        /// </summary>
        /// <param name="unit">Give unit</param>
        void Remove(IUnit unit);

        /// <summary>
        /// Moves the unit from one coordinates to an other.
        /// </summary>
        /// <param name="unit">Unit to be moved</param>
        /// <param name="newX">new x coordinates</param>
        /// <param name="newY">new y coordinates</param>
        void Move(IUnit unit, int newX, int newY);
    }
}
