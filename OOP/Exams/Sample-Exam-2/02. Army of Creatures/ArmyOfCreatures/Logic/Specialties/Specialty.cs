namespace ArmyOfCreatures.Logic.Specialties
{
    using Battles;

    public abstract class Specialty
    {
        public abstract void ApplyWhenAttacking(ICreaturesInBattle attackerWithSpecialty, ICreaturesInBattle defender);

        public abstract void ApplyWhenDefending(ICreaturesInBattle defenderWithSpecialty, ICreaturesInBattle attacker);

        public abstract void ApplyAfterDefending(ICreaturesInBattle defenderWithSpecialty);

        public virtual decimal ChangeDamageWhenAttacking(ICreaturesInBattle attackerWithSpecialty, ICreaturesInBattle defender, decimal currentDamage)
        {
            return currentDamage;
        }

        public abstract void ApplyOnSkip(ICreaturesInBattle skipCreature);

        public override string ToString()
        {
            return this.GetType().Name;
        }
    }
}
