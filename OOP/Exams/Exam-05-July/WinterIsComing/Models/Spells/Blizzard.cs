namespace WinterIsComing.Models.Spells
{
    using Contracts;

    public class Blizzard : ISpell
    {
        private const int BlizzardEnergyCost = 40;

        public Blizzard(int damage)
        {
            this.Damage = damage;
            this.EnergyCost = BlizzardEnergyCost;
        }

        public int Damage { get; set; }

        public int EnergyCost { get; set; }
    }
}