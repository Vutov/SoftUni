namespace ArmyOfCreatures.Logic
{
    using Creatures;

    public interface ICreaturesFactory
    {
        Creature CreateCreature(string name);
    }
}
