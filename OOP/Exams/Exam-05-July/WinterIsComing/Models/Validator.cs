namespace WinterIsComing.Models
{
    using Contracts;
    using Core;
    using Core.Exceptions;

    public static class Validator
    {
        public static bool HasEnoughEnergy(IUnit unit, ISpell spell)
        {
            if (unit.EnergyPoints - spell.EnergyCost < 0)
            {
                var message = string.Format(GlobalMessages.NotEnoughEnergy, unit.Name, spell.GetType().Name);
                throw new NotEnoughEnergyException(message);
            }

            return true;
        }
    }
}
