namespace WinterIsComing.Models.Units
{
    using Contracts;
    using CombatHandlers;

    public class Warrior : GameUnit
    {
        private const int WarriorAttack = 120;
        private const int WarriorHealth = 180;
        private const int WarriorDefense = 70;
        private const int WarriorEnergy = 60;
        private const int WarriorRange = 1;

        public Warrior(int x, int y, string name)
            : base(x, y, name, WarriorRange, WarriorAttack, WarriorHealth, WarriorDefense, WarriorEnergy)
        {
            this.CombatHandler = new WarriorCombatHandler(this);
        }

        public override ICombatHandler CombatHandler { get; protected set; }
    }
}
