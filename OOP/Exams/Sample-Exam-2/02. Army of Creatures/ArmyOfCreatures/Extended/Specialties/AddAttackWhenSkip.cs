using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArmyOfCreatures.Logic.Battles;
using ArmyOfCreatures.Logic.Specialties;

namespace ArmyOfCreatures.Extended.Specialties
{
    public class AddAttackWhenSkip : Specialty
    {
        private const int MinAttackToAdd = 1;
        private const int MaxAttackToAdd = 10;
        private int attackToAdd;

        public AddAttackWhenSkip(int attackToAdd)
        {
            this.AttackToAdd = attackToAdd;
        }

        public int AttackToAdd
        {
            get
            {
                return this.attackToAdd;
            }

            private set
            {
                if (value < MinAttackToAdd || value > MaxAttackToAdd)
                {
                    string message = string.Format(
                        "attackToAdd should be between {0} and {1}, inclusive",
                        MinAttackToAdd,
                        MaxAttackToAdd);

                    throw new ArgumentOutOfRangeException("attackToAdd", message);
                }

                this.attackToAdd = value;
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
            if (skipCreature == null)
            {
                throw new ArgumentNullException("skipCreature");
            }

            skipCreature.PermanentAttack += this.AttackToAdd;
        }

        public override string ToString()
        {
            return string.Format("AddAttackWhenSkip({0})", this.AttackToAdd);
        }
    }
}
