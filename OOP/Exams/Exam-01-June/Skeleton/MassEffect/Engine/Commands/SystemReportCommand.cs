using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MassEffect.GameObjects.Locations;
using MassEffect.GameObjects.Ships;
using MassEffect.Interfaces;

namespace MassEffect.Engine.Commands
{
    class SystemReportCommand : Command
    {
        public SystemReportCommand(IGameEngine gameEngine) : base(gameEngine)
        {
        }

        public override void Execute(string[] commandArgs)
        {
            var system = new StarSystem(commandArgs[1]);
            var ships = this.GameEngine.Starships.Cast<Ship>().ToList();
            var intactShips = new List<Ship>();
            var destoyedShips = new List<Ship>();

            ships.ForEach(s =>
            {
                if (s.Location.Name == system.Name)
                {
                    if (s.Health > 0)
                    {
                        intactShips.Add(s);
                    }
                    else
                    {
                        destoyedShips.Add(s);
                    }
                }
            });

            /*
             * Intact ships should be sorted by health in descending order and by shields as 
             * secondary criteria (again in descending order). Destroyed ships should ordered 
             * alphabetically by name in ascending order. 
             */

            var sortedIntactShips = intactShips.OrderByDescending(s => s.Health).ThenByDescending(s => s.Shields).ToList();
            var sortedDestoyedShips = destoyedShips.OrderBy(s => s.Name).ToList();


            Console.WriteLine(Messages.IntactShips);
            if (sortedIntactShips.Count > 0)
            {
                sortedIntactShips.ForEach(ship =>
                {
                    Console.WriteLine(ship);
                    Console.WriteLine(Messages.Location, ship.Location.Name);
                    Console.WriteLine(Messages.Health, ship.Health);
                    Console.WriteLine(Messages.Shields, ship.Shields);
                    Console.WriteLine(Messages.Damage, ship.Damage);
                    Console.WriteLine(Messages.Fuel, ship.Fuel);

                    var enhansments = new List<string>();
                    ship.Enhancements.ToList().ForEach(e => enhansments.Add(e.Name));
                    Console.WriteLine(Messages.Enhancements,
                        enhansments.Count == 0 ? "N/A" : string.Join(", ", enhansments));

                    if (ship is Frigate)
                    {
                        Console.WriteLine(Messages.ProjectilesFired, ship.ProjectilesFired);
                    }
                });
            }
            else
            {
                Console.WriteLine("N/A");
            }

            Console.WriteLine(Messages.DestroyedShips);
            if (sortedDestoyedShips.Count > 0)
            {
                sortedDestoyedShips.ForEach(ship =>
                {
                    Console.WriteLine(ship);
                    Console.WriteLine(Messages.Destoyed);
                });
            }
            else
            {
                Console.WriteLine("N/A");
            }
        }
    }
}
