namespace WinterIsComing.Contracts
{
    public interface IUnit
    {
        int X { get; set; }

        int Y { get; set; }

        string Name { get; }

        int Range { get; }

        int AttackPoints { get; set; }

        int HealthPoints { get; set; }

        int DefensePoints { get; set; }

        int EnergyPoints { get; set; }

        ICombatHandler CombatHandler { get; }
    }
}
