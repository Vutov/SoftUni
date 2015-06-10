using System;
using MassEffect.Engine;

namespace MassEffect.GameObjects
{
    using System.Collections.Generic;
    using System.Linq;
    
    using MassEffect.Exceptions;
    using MassEffect.GameObjects.Locations;
    using MassEffect.Interfaces;

    public class Galaxy
    {
        public HashSet<StarSystem> StarSystems { get; set; }

        public Galaxy()
        {
            this.StarSystems = new HashSet<StarSystem>();
        }

        public StarSystem GetStarSystemByName(string name)
        {
            return this.StarSystems
                .First(s => s.Name == name);
        }

        public void TravelTo(IStarship ship, StarSystem destination)
        {
            var startLocation = ship.Location;

            if (startLocation.Equals(destination))
            {
                Console.WriteLine(Messages.ShipAlreadyInStarSystem, startLocation.Name);
                return;
            }

            if (!startLocation.NeighbourStarSystems.ContainsKey(destination))
            {
                throw new LocationOutOfRangeException(string.Format(
                    "Cannot travel directly from {0} to {1}",
                    startLocation.Name, destination.Name));
            }

            double requiredFuel = startLocation.NeighbourStarSystems[destination];
            if (ship.Fuel < requiredFuel)
            {
                throw new InsufficientFuelException(string.Format(
                    "Not enough fuel to travel to {0} - {1}/{2}", 
                    destination.Name, ship.Fuel, requiredFuel));
            }

            ship.Fuel -= requiredFuel;
            ship.Location = destination;

            Console.WriteLine(Messages.ShipTraveled, ship.Name, startLocation.Name, destination.Name);
        }
    }
}
