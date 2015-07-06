namespace WinterIsComing.Models.Spells
{
    using Contracts;

    public class FireBreath : ISpell
    {
        private const int FireBreathEnergyCost = 30;

        public FireBreath(int damage)
        {
            this.Damage = damage;
            this.EnergyCost = FireBreathEnergyCost;
        }

        public int Damage { get; set; }

        public int EnergyCost { get; set; }
    }
}
