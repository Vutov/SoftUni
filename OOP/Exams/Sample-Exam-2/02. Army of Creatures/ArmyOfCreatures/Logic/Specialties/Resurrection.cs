namespace ArmyOfCreatures.Logic.Specialties
{
    using System;
    using Battles;

    public class Resurrection : Specialty
    {
        public override void ApplyWhenAttacking(ICreaturesInBattle attackerWithSpecialty, ICreaturesInBattle defender)
        {
        }

        public override void ApplyWhenDefending(ICreaturesInBattle defenderWithSpecialty, ICreaturesInBattle attacker)
        {
        }

        public override void ApplyAfterDefending(ICreaturesInBattle defenderWithSpecialty)
        {
            if (defenderWithSpecialty == null)
            {
                throw new ArgumentNullException("defenderWithSpecialty");
            }

            if (defenderWithSpecialty.TotalHitPoints > 0)
            {
                defenderWithSpecialty.TotalHitPoints = defenderWithSpecialty.Count
                                                       * defenderWithSpecialty.Creature.HealthPoints;
            }
        }

        public override void ApplyOnSkip(ICreaturesInBattle skipCreature)
        {
        }
    }
}
