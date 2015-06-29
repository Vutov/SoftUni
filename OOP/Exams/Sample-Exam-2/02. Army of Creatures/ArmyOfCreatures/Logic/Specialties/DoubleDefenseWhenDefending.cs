namespace ArmyOfCreatures.Logic.Specialties
{
    using System;
    using System.Globalization;
    using Battles;

    public class DoubleDefenseWhenDefending : Specialty
    {
        private int rounds;

        public DoubleDefenseWhenDefending(int rounds)
        {
            this.Rounds = rounds;
        }

        public int Rounds
        {
            get
            {
                return this.rounds;
            }

            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("rounds", "The number of rounds should be greater than 0");
                }

                this.rounds = value;
            }
        }

        public override void ApplyWhenAttacking(ICreaturesInBattle attackerWithSpecialty, ICreaturesInBattle defender)
        {
        }

        public override void ApplyWhenDefending(ICreaturesInBattle defenderWithSpecialty, ICreaturesInBattle attacker)
        {
            if (defenderWithSpecialty == null)
            {
                throw new ArgumentNullException("defenderWithSpecialty");
            }

            if (attacker == null)
            {
                throw new ArgumentNullException("attacker");
            }

            if (this.Rounds <= 0)
            {
                // Effect expires after fixed number of rounds
                return;
            }

            defenderWithSpecialty.CurrentDefense *= 2;
            this.rounds--;
        }

        public override void ApplyAfterDefending(ICreaturesInBattle defenderWithSpecialty)
        {
        }

        public override void ApplyOnSkip(ICreaturesInBattle skipCreature)
        {
        }

        public override string ToString()
        {
            return string.Format(CultureInfo.InvariantCulture, "{0}({1})", base.ToString(), this.Rounds);
        }
    }
}
