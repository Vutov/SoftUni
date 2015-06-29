using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArmyOfCreatures.Logic.Creatures;
using ArmyOfCreatures.Logic.Specialties;

namespace ArmyOfCreatures.Extended.Creatures
{
    public class AncientBehemoth: Creature
    {
        private const int DefaultBehemothAttack = 19;
        private const int DefaultBehemothDefense = 19;
        private const int DefaultBehemothHealth = 300;
        private const decimal DefaultBehemothDamage = 40;
        private const int BehemothEnemyDefenseReductionPercentage = 80;
        private const int BehemothDoubleDefenseRounds = 5;

        public AncientBehemoth()
            : base(DefaultBehemothAttack, DefaultBehemothDefense, DefaultBehemothHealth, DefaultBehemothDamage)
        {
            this.AddSpecialty(new ReduceEnemyDefenseByPercentage(BehemothEnemyDefenseReductionPercentage));
            this.AddSpecialty(new DoubleDefenseWhenDefending(BehemothDoubleDefenseRounds));
        }
    }
}
