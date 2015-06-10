namespace MassEffect.Engine.Factories
{
    using System;

    using MassEffect.GameObjects.Locations;
    using MassEffect.GameObjects.Ships;
    using MassEffect.Interfaces;

    public class ShipFactory
    {
        public IStarship CreateShip(StarshipType type, string name, StarSystem location)
        {
            IStarship ship;
            switch (type)
            {
                case StarshipType.Frigate:
                    ship = new Frigate(name, location);
                    break;
                case StarshipType.Cruiser:
                    ship = new Cruiser(name, location);
                    break;
                case StarshipType.Dreadnought:
                    ship = new Dreadnought(name, location);
                    break;
                default:
                    throw new NotSupportedException("Starship type not supported.");
            }

            Console.WriteLine(Messages.CreatedShip, ship.GetType().Name, ship.Name);
            return ship;
        }
    }
}
