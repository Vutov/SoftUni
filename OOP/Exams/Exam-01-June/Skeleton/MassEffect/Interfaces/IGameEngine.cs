namespace MassEffect.Interfaces
{    
    using System.Collections.Generic;

    using MassEffect.Engine.Factories;
    using MassEffect.GameObjects;

    public interface IGameEngine
    {
        ShipFactory ShipFactory { get; }

        EnhancementFactory EnhancementFactory { get; }

        IList<IStarship> Starships { get; }

        Galaxy Galaxy { get; }

        ICommandManager CommandManager { get; }

        bool IsRunning { get; set; }

        void Run();
    }
}
