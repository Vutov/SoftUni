using System;
using System.Collections.Generic;
using MassEffect.Engine.Factories;
using MassEffect.GameObjects.Enhancements;
using MassEffect.GameObjects.Locations;
using MassEffect.GameObjects.Ships;

namespace MassEffect.Engine.Commands
{
    using MassEffect.Interfaces;

    public class CreateCommand : Command
    {
        public CreateCommand(IGameEngine gameEngine) 
            : base(gameEngine)
        {
        }

        public override void Execute(string[] commandArgs)
        {
            StarshipType shipType = (StarshipType) Enum.Parse( typeof(StarshipType), commandArgs[1], true );
            var shipName = commandArgs[2];
            StarSystem system = this.GameEngine.Galaxy.GetStarSystemByName(commandArgs[3]);
            var enchans = new List<Enhancement>();
            var enchansmentFactory = new EnhancementFactory();
            for (int i = 4; i < commandArgs.Length; i++)
            {
                var ench = enchansmentFactory.Create((EnhancementType)Enum.Parse(typeof(EnhancementType), commandArgs[i], true));
                enchans.Add(ench);
            }

            var shipFactory = new ShipFactory();
            var ship = shipFactory.CreateShip(shipType, shipName, system);
            enchans.ForEach(e => ship.AddEnhancement(e));

            this.GameEngine.Starships.Add(ship);
        }
    }
}
