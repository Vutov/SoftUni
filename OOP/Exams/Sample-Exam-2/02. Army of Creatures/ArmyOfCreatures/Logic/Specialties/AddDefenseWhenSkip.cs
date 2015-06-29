namespace ArmyOfCreatures.Logic.Specialties
{
    using System;
    using System.Globalization;
    using Battles;

    public class AddDefenseWhenSkip : Specialty
    {
        private const int MinDefenseToAdd = 1;
        private const int MaxDefenseToAdd = 20;

        private int defenseToAdd;

        public AddDefenseWhenSkip(int defenseToAdd)
        {
            this.DefenseToAdd = defenseToAdd;
        }

        public int DefenseToAdd
        {
            get
            {
                return this.defenseToAdd;
            }

            private set
            {
                if (value < MinDefenseToAdd || value > MaxDefenseToAdd)
                {
                    string message = string.Format(
                        "defenseToAdd should be between {0} and {1}, inclusive",
                        MinDefenseToAdd,
                        MaxDefenseToAdd);

                    throw new ArgumentOutOfRangeException("defenseToAdd", message);
                }

                this.defenseToAdd = value;
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

            skipCreature.PermanentDefense += this.DefenseToAdd;
        }

        public override string ToString()
        {
            return string.Format(CultureInfo.InvariantCulture, "{0}({1})", base.ToString(), this.DefenseToAdd);
        }
    }
}
