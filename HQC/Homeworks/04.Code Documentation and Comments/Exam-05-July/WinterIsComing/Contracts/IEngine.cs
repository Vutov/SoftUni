namespace WinterIsComing.Contracts
{
    using System.Collections.Generic;

    /// <summary>
    /// Game Engine, containing all the necessary logic for the game.
    /// </summary>
    public interface IEngine
    {
        /// <summary>
        /// Gets all units in the Engine.
        /// </summary>
        IEnumerable<IUnit> Units { get; } 

        /// <summary>
        /// Gets all units in the container.
        /// </summary>
        IUnitContainer UnitContainer { get; }

        /// <summary>
        /// Gets output writer.
        /// </summary>
        IOutputWriter OutputWriter { get; }

        /// <summary>
        /// Gets special effector.
        /// </summary>
        IUnitEffector UnitEffector { get; }

        /// <summary>
        /// Start the Engine.
        /// </summary>
        void Start();

        /// <summary>
        /// Stops the Engine.
        /// </summary>
        void Stop();

        /// <summary>
        /// Inserts given Unit to the Engine.
        /// </summary>
        /// <param name="unit">Unit to be inserted</param>
        void InsertUnit(IUnit unit);

        /// <summary>
        /// Removes giver Unit from the Engine
        /// </summary>
        /// <param name="unit">Unit to be removed</param>
        void RemoveUnit(IUnit unit);
    }
}
