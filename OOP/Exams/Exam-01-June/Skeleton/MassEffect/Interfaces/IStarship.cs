namespace MassEffect.Interfaces
{
    using MassEffect.GameObjects.Locations;

    public interface IStarship : IEnhanceable
    {
        string Name { get; set; }

        int Health { get; set; }

        int Shields { get; set; }

        int Damage { get; set; }

        double Fuel { get; set; }

        StarSystem Location { get; set; }

        IProjectile ProduceAttack();

        void RespondToAttack(IProjectile attack);
    }
}
