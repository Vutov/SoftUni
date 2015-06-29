namespace ArmyOfCreatures.Logic.Creatures
{
    using Specialties;

    public class Devil : Creature
    {
        private const int DefaultDevilAttack = 19;
        private const int DefaultDevilDefense = 26;
        private const int DefaultDevilHealth = 160;
        private const decimal DefaultDevilDamage = 35;
        private const int DevilEnemyDefenseReductionPercentage = 100;

        public Devil()
            : base(DefaultDevilAttack, DefaultDevilDefense, DefaultDevilHealth, DefaultDevilDamage)
        {
            this.AddSpecialty(new Hate(typeof(Angel)));
            this.AddSpecialty(new Hate(typeof(Archangel)));
            this.AddSpecialty(new ReduceEnemyDefenseByPercentage(DevilEnemyDefenseReductionPercentage));
        }
    }
}