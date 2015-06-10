using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MassEffect.GameObjects.Enhancements;
using MassEffect.GameObjects.Ships;

namespace MassEffect.Engine.Commands
{
    using MassEffect.Interfaces;

    public class StatusReportCommand : Command
    {
        public StatusReportCommand(IGameEngine gameEngine)
            : base(gameEngine)
        {
        }

        public override void Execute(string[] commandArgs)
        {
            var ships = this.GameEngine.Starships.ToList();
            var shipName = commandArgs[1];
            Ship ship = (Ship) ships.Find(s => s.Name == shipName);

            Console.WriteLine(ship);
            if (ship.Health <= 0)
            {
                Console.WriteLine(Messages.Destoyed);
            }
            else
            {
                Console.WriteLine(Messages.Location, ship.Location.Name);
                Console.WriteLine(Messages.Health, ship.Health);
                Console.WriteLine(Messages.Shields, ship.Shields);
                Console.WriteLine(Messages.Damage, ship.Damage);
                Console.WriteLine(Messages.Fuel, ship.Fuel);

                var enhansments = new List<string>();
                ship.Enhancements.ToList().ForEach(e => enhansments.Add(e.Name));
                Console.WriteLine(Messages.Enhancements, enhansments.Count == 0 ? "N/A" : string.Join(", ", enhansments));

                if (ship is Frigate)
                {
                    Console.WriteLine(Messages.ProjectilesFired, ship.ProjectilesFired);
                }
            }


        }
    }
}
