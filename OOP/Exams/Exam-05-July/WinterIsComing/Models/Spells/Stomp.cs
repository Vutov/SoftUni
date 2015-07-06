namespace WinterIsComing.Models.Spells
{
    using Contracts;
    public class Stomp : ISpell
    {
        private const int StompEnergyCost = 10;

        public Stomp(int damage)
        {
            this.Damage = damage;
            this.EnergyCost = StompEnergyCost;
        }

        public int Damage { get; set; }

        public int EnergyCost { get; set; }
    }
}
