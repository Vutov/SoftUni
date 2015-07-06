namespace WinterIsComing.Contracts
{
    using System.Collections.Generic;

    public interface ICombatHandler
    {
        IUnit Unit { get; set; }

        IEnumerable<IUnit> PickNextTargets(IEnumerable<IUnit> candidateTargets);

        ISpell GenerateAttack();
    }
}
