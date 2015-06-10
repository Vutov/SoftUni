namespace MassEffect
{
    using MassEffect.Engine;
    using MassEffect.GameObjects;
    using MassEffect.GameObjects.Locations;
    using MassEffect.Interfaces;

    public class MassEffectMain
    {
        static void Main()
        {
            Galaxy galaxy = new Galaxy();
            SeedStarSystems(galaxy);

            ICommandManager commandManager = new ExtendedCommandManager();
            IGameEngine engine = new GameEngine(commandManager, galaxy);
            engine.Run();
        }

        public static void SeedStarSystems(Galaxy galaxy)
        {
            var artemisTau = new StarSystem("Artemis-Tau");
            var serpentNebula = new StarSystem("Serpent-Nebula");
            var hadesGamma = new StarSystem("Hades-Gamma");
            var keplerVerge = new StarSystem("Kepler-Verge");

            galaxy.StarSystems.Add(artemisTau);
            galaxy.StarSystems.Add(serpentNebula);
            galaxy.StarSystems.Add(hadesGamma);
            galaxy.StarSystems.Add(keplerVerge);

            artemisTau.NeighbourStarSystems.Add(serpentNebula, 50);
            artemisTau.NeighbourStarSystems.Add(keplerVerge, 120);

            serpentNebula.NeighbourStarSystems.Add(artemisTau, 50);
            serpentNebula.NeighbourStarSystems.Add(hadesGamma, 360);

            hadesGamma.NeighbourStarSystems.Add(serpentNebula, 360);
            hadesGamma.NeighbourStarSystems.Add(keplerVerge, 145);

            keplerVerge.NeighbourStarSystems.Add(hadesGamma, 145);
            keplerVerge.NeighbourStarSystems.Add(artemisTau, 120);
        }
    }
}
