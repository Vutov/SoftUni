using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArmyOfCreatures.Logic.Creatures;
using ArmyOfCreatures.Logic.Specialties;

namespace ArmyOfCreatures.Extended.Creatures
{
    public class Goblin : Creature
    {
        private const int DefaultGoblinAttack = 4;
        private const int DefaultGoblinDefense = 2;
        private const int DefaultGoblinHealth = 5;
        private const decimal DefaultGoblinDamage = 1.5M;

        public Goblin()
            : base(DefaultGoblinAttack, DefaultGoblinDefense, DefaultGoblinHealth, DefaultGoblinDamage)
        {

        }
    }
}
