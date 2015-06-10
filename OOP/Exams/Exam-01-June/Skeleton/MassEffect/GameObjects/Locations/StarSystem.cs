namespace MassEffect.GameObjects.Locations
{
    using System.Collections.Generic;

    public class StarSystem
    {
        public StarSystem(string name)
        {
            this.Name = name;
            this.NeighbourStarSystems = new Dictionary<StarSystem, double>();
        }

        public string Name { get; set; }

        public IDictionary<StarSystem, double> NeighbourStarSystems { get; set; }
    }
}
