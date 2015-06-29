using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArmyOfCreatures.Logic.Specialties;
using ArmyOfCreatures.Logic.Battles;
using ArmyOfCreatures.Logic.Specialties;


namespace ArmyOfCreatures.Extended.Specialties
{
    class DoubleAttackWhenAttacking : Specialty
    {
        private const int MinRounds = 0;
        private int rounds;
        
        public DoubleAttackWhenAttacking(int rounds)
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
                if (value < MinRounds)
                {
                    string message = string.Format(
                        "Rounds should be more than {0}",
                        MinRounds);

                    throw new ArgumentOutOfRangeException("Rounds", message);
                }

                this.rounds = value;
            }
        }

        public override void ApplyWhenAttacking(ICreaturesInBattle attackerWithSpecialty, ICreaturesInBattle defender)
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
                return;
            }

            attackerWithSpecialty.CurrentAttack *= 2;
            this.rounds--;
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

        public override string ToString()
        {
            return string.Format("DoubleAttackWhenAttacking({0})", this.Rounds);
        }
    }
}
