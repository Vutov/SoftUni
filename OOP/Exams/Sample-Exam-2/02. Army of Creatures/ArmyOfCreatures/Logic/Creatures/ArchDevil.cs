namespace ArmyOfCreatures.Logic.Creatures
{
    using Specialties;

    public class ArchDevil : Creature
    {
        private const int DefaultArchDevilAttack = 21;
        private const int DefaultArchDevilDefense = 28;
        private const int DefaultArchDevilHealth = 200;
        private const decimal DefaultArchDevilDamage = 35;
        private const int ArchDevilEnemyDefenseReductionPercentage = 100;

        public ArchDevil()
            : base(DefaultArchDevilAttack, DefaultArchDevilDefense, DefaultArchDevilHealth, DefaultArchDevilDamage)
        {
            this.AddSpecialty(new Hate(typeof(Angel)));
            this.AddSpecialty(new Hate(typeof(Archangel)));
            this.AddSpecialty(new ReduceEnemyDefenseByPercentage(ArchDevilEnemyDefenseReductionPercentage));
        }
    }
}