namespace WinterIsComing.Models.Spells
{
    using Contracts;

    public class Cleave : ISpell
    {
        private const int CleaveEnergyCost = 15;
        public Cleave(int damage)
        {
            this.Damage = damage;
            this.EnergyCost = CleaveEnergyCost;
        }

        public int Damage { get; private set; }

        public int EnergyCost { get; private set; }
    }
}
