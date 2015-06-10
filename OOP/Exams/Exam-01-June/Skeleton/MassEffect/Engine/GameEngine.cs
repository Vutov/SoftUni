namespace MassEffect.Engine
{
    using System;
    using System.Collections.Generic;

    using MassEffect.Engine.Factories;
    using MassEffect.Exceptions;
    using MassEffect.GameObjects;
    using MassEffect.Interfaces;

    public sealed class GameEngine : IGameEngine
    {
        public GameEngine(ICommandManager commandManager, Galaxy galaxy)
        {
            this.CommandManager = commandManager;
            this.Galaxy = galaxy;
            this.ShipFactory = new ShipFactory();
            this.EnhancementFactory = new EnhancementFactory();
            this.Starships = new List<IStarship>();
        }

        public EnhancementFactory EnhancementFactory { get; set; }

        public ShipFactory ShipFactory { get; private set; }

        public IList<IStarship> Starships { get; private set; }

        public Galaxy Galaxy { get; private set; }

        public ICommandManager CommandManager { get; set; }

        public bool IsRunning { get; set; }

        public void Run()
        {
            this.IsRunning = true;
            this.CommandManager.Engine = this;
            this.CommandManager.SeedCommands();

            do
            {
                string command = Console.ReadLine();

                try
                {
                    this.CommandManager.ProcessCommand(command);
                }
                catch (ShipException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            } 
            while (this.IsRunning);
        }
    }
}
