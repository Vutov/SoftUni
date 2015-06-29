namespace ArmyOfCreatures.Logic.Specialties
{
    using System;
    using System.Globalization;
    using Battles;

    public class Hate : Specialty
    {
        private Type creatureTypeToHate;

        public Hate(Type creatureTypeToHate)
        {
            this.CreatureTypeToHate = creatureTypeToHate;
        }

        public Type CreatureTypeToHate
        {
            get
            {
                return this.creatureTypeToHate;
            }

            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("creatureTypeToHate");
                }

                this.creatureTypeToHate = value;
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

        public override decimal ChangeDamageWhenAttacking(
            ICreaturesInBattle attackerWithSpecialty,
            ICreaturesInBattle defender,
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

            if (defender.Creature.GetType() == this.CreatureTypeToHate)
            {
                return currentDamage * 1.5M;
            }

            return currentDamage;
        }

        public override void ApplyOnSkip(ICreaturesInBattle skipCreature)
        {
        }

        public override string ToString()
        {
            return string.Format(
                CultureInfo.InvariantCulture,
                "{0}({1})",
                base.ToString(),
                this.CreatureTypeToHate.Name);
        }
    }
}
