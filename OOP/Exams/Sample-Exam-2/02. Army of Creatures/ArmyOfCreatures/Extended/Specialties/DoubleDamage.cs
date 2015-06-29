using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArmyOfCreatures.Logic.Battles;
using ArmyOfCreatures.Logic.Specialties;

namespace ArmyOfCreatures.Extended.Specialties
{
    class DoubleDamage : Specialty
    {
        private const int MinRounds = 0;
        private const int MaxRounds = 10;
        private int rounds;

        public DoubleDamage(int rounds)
        {
            this.Rounds = rounds;
        }

        public int Rounds
        {
            get
            {
                return this.rounds;
            }
            set
            {
                if (value < MinRounds || value > MaxRounds)
                {
                    string message = string.Format(
                        "Rounds should be between {0} and {1}, inclusive",
                        MinRounds,
                        MaxRounds);

                    throw new ArgumentOutOfRangeException("Rounds", message);
                }

                this.rounds = value;
            }
        }

        public override void ApplyWhenAttacking(ICreaturesInBattle attackerWithSpecialty, ICreaturesInBattle defender)
        {

        }

        public override void ApplyWhenDefending(ICreaturesInBattle defenderWithSpecialty, ICreaturesInBattle attacker)
        {

        }

        public override void ApplyAfterDefending(ICreaturesInBattle defenderWithSpecialty)
        {

        }

        public override void ApplyOnSkip(ICreaturesInBattle skipCreature)
        {

        }

        public override decimal ChangeDamageWhenAttacking(ICreaturesInBattle attackerWithSpecialty, ICreaturesInBattle defender,
            decimal currentDamage)
        {
            if (attackerWithSpecialty == null)
            {
                throw new ArgumentNullException("attackerWithSpecialty");
            }

            if (defender == null)
            {
                throw new ArgumentNullException("defender");
            }

            if (this.Rounds <= 0)
            {
                // Effect expires after fixed number of rounds
                return currentDamage;
            }

            this.rounds--;

            return currentDamage * 2;
        }

        public override string ToString()
        {
            return string.Format("DoubleDamage({0})", this.Rounds);
        }
    }
}
