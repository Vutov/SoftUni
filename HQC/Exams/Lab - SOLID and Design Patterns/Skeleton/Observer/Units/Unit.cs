namespace Skyrim.Units
{
    public abstract class Unit
    {
        protected Unit(string name, int attackPoints, int healthPoints)
        {
            this.Name = name;
            this.AttackPoints = attackPoints;
            this.HealthPoints = healthPoints;
        }

        public string Name { get; set; }

        public virtual int AttackPoints { get; set; }

        public virtual int HealthPoints { get; set; }
    }
}
