using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArmyOfCreatures.Logic.Creatures;
using ArmyOfCreatures.Logic.Specialties;

namespace ArmyOfCreatures.Extended.Creatures
{
    class Griffin: Creature
    {
        private const int DefaultGriffinAttack = 8;
        private const int DefaultGriffinDefense = 8;
        private const int DefaultGriffinHealth = 25;
        private const decimal DefaultGriffinDamage = 4.5M;
        private const int GriffinDefenseRounds = 5;
        private const int GriffinDefenseWhenSkip = 3;

        public Griffin()
            : base(DefaultGriffinAttack, DefaultGriffinDefense, DefaultGriffinHealth, DefaultGriffinDamage)
        {
            this.AddSpecialty(new DoubleDefenseWhenDefending(GriffinDefenseRounds));
            this.AddSpecialty(new AddDefenseWhenSkip(GriffinDefenseWhenSkip));
            this.AddSpecialty(new Hate(typeof(WolfRaider)));
        }
    }
}
