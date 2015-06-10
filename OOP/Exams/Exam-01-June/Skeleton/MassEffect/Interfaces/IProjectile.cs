namespace MassEffect.Interfaces
{
    public interface IProjectile
    {
        int Damage { get; set; }

        void Hit(IStarship ship);
    }
}
