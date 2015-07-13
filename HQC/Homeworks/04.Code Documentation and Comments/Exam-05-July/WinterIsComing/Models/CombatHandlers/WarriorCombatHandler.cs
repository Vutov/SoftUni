namespace WinterIsComing.Models.CombatHandlers
{
    using System.Collections.Generic;
    using System.Linq;
    using Contracts;
    using Spells;

    public class WarriorCombatHandler : ICombatHandler
    {
        public WarriorCombatHandler(IUnit unit)
        {
            this.Unit = unit;
        }

        public IUnit Unit { get; set; }

        public IEnumerable<IUnit> PickNextTargets(IEnumerable<IUnit> candidateTargets)
        {
            var targets = candidateTargets.OrderBy(t => t.HealthPoints).ThenBy(t => t.Name);

            if (targets.Count() != 0)
            {
                return new List<IUnit>() { targets.First() };
            }

            return new List<IUnit>();
        }

        public ISpell GenerateAttack()
        {
            var damage = this.Unit.AttackPoints;
            if (this.Unit.HealthPoints <= 80)
            {
                damage += this.Unit.HealthPoints * 2;
            }

            var cleave = new Cleave(damage);

            if (this.Unit.HealthPoints > 50)
            {
                Validator.HasEnoughEnergy(this.Unit, cleave);

                Unit.EnergyPoints -= cleave.EnergyCost;
            }

            return cleave;
        }
    }
}
