using System;
using System.Linq;
using MassEffect.GameObjects;
using MassEffect.GameObjects.Locations;

namespace MassEffect.Engine.Commands
{
    using MassEffect.Interfaces;

    public class PlotJumpCommand : Command
    {
        public PlotJumpCommand(IGameEngine gameEngine)
            : base(gameEngine)
        {
        }

        public override void Execute(string[] commandArgs)
        {
            var ships = this.GameEngine.Starships.ToList();
            var shipName = commandArgs[1];
            var destination = this.GameEngine.Galaxy.GetStarSystemByName(commandArgs[2]);
            var ship = ships.Find(s => s.Name == shipName);
            if (ship.Health <= 0)
            {
                Console.WriteLine(Messages.ShipAlreadyDestroyed);
                return;
            }

            this.GameEngine.Galaxy.TravelTo(ship, destination);
        }
    }
}
