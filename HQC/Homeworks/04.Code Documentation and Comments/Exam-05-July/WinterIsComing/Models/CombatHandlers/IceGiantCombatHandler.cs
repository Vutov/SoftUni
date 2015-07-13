namespace WinterIsComing.Models.CombatHandlers
{
    using System.Collections.Generic;
    using System.Linq;
    using Contracts;
    using Spells;

    public class IceGiantCombatHandler : ICombatHandler
    {
        private const int BonusAttackPerAttack = 5;
        public IceGiantCombatHandler(IUnit unit)
        {
            this.Unit = unit;
        }

        public IUnit Unit { get; set; }

        public IEnumerable<IUnit> PickNextTargets(IEnumerable<IUnit> candidateTargets)
        {
            if (this.Unit.HealthPoints <= 150)
            {
                if (candidateTargets.Count() != 0)
                {
                    return new List<IUnit>() { candidateTargets.First() };
                }

                return new List<IUnit>();
            }

            return candidateTargets;
        }

        public ISpell GenerateAttack()
        {
            var stomp = new Stomp(this.Unit.AttackPoints);

            Validator.HasEnoughEnergy(this.Unit, stomp);

            Unit.EnergyPoints -= stomp.EnergyCost;

            this.Unit.AttackPoints += BonusAttackPerAttack;

            return stomp;
        }
    }
}
