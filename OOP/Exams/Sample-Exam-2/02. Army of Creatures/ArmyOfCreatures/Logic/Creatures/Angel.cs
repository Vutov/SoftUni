namespace ArmyOfCreatures.Logic.Creatures
{
    using Specialties;

    public class Angel : Creature
    {
        private const int DefaultAngelAttack = 20;
        private const int DefaultAngelDefense = 20;
        private const int DefaultAngelHealth = 200;
        private const decimal DefaultAngelDamage = 50;

        public Angel()
            : base(DefaultAngelAttack, DefaultAngelDefense, DefaultAngelHealth, DefaultAngelDamage)
        {
            this.AddSpecialty(new Hate(typeof(Devil)));
            this.AddSpecialty(new Hate(typeof(ArchDevil)));
        }
    }
}