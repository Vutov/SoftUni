namespace Observer.Interfaces
{
    using Skyrim.Items;

    public interface IDragonDeathObserver
    {
        void Update(Weapon weapon);
    }
}
