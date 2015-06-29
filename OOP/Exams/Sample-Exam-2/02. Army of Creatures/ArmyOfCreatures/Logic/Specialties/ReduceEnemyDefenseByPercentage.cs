namespace ArmyOfCreatures.Logic.Specialties
{
    using System;
    using System.Globalization;

    using Battles;

    public class ReduceEnemyDefenseByPercentage : Specialty
    {
        private const int MinPercentage = 0;
        private const int MaxPercentage = 100;

        private decimal percentage;

        public ReduceEnemyDefenseByPercentage(decimal percentage)
        {
            this.Percentage = percentage;
        }

        private decimal Percentage
        {
            get
            {
                return this.percentage;
            }

            set
            {
                if (value < MinPercentage || value > MaxPercentage)
                {
                    string message = string.Format(
                        "The percentage argument should be between {0} and {1}, inclusive",
                        MinPercentage,
                        MaxPercentage);

                    throw new ArgumentOutOfRangeException("percentage", message);
                }

                this.percentage = value;
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

            var reduceDefenseBy = (int)(defender.CurrentDefense * (this.Percentage / 100.0M));
            defender.CurrentDefense = defender.CurrentDefense - reduceDefenseBy;
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
            return string.Format(CultureInfo.InvariantCulture, "{0}({1})", base.ToString(), this.Percentage);
        }
    }
}
