namespace ArmyOfCreatures.Logic.Creatures
{
    using Specialties;

    public class Behemoth : Creature
    {
        private const int DefaultBehemothAttack = 17;
        private const int DefaultBehemothDefense = 17;
        private const int DefaultBehemothHealth = 160;
        private const decimal DefaultBehemothDamage = 40;
        private const int BehemothEnemyDefenseReductionPercentage = 40;

        public Behemoth()
            : base(DefaultBehemothAttack, DefaultBehemothDefense, DefaultBehemothHealth, DefaultBehemothDamage)
        {
            this.AddSpecialty(new ReduceEnemyDefenseByPercentage(BehemothEnemyDefenseReductionPercentage));
        }
    }
}
