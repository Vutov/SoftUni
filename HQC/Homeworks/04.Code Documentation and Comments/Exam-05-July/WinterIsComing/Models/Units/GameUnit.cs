namespace WinterIsComing.Models.Units
{
    using Contracts;

    public abstract class GameUnit : IUnit
    {
        protected GameUnit(int x, int y, string name, int range,
            int attackPoints, int healthPoints, int defensePoints,
            int energyPoints)
        {
            this.X = x;
            this.Y = y;
            this.Name = name;
            this.Range = range;
            this.AttackPoints = attackPoints;
            this.HealthPoints = healthPoints;
            this.DefensePoints = defensePoints;
            this.EnergyPoints = energyPoints;
        }

        public int X { get; set; }

        public int Y { get; set; }

        public string Name { get; private set; }

        public int Range { get; private set; }

        public int AttackPoints { get; set; }

        public int HealthPoints { get; set; }

        public int DefensePoints { get; set; }

        public int EnergyPoints { get; set; }

        public abstract ICombatHandler CombatHandler { get; protected set; }

        public override string ToString()
        {
            if (this.HealthPoints > 0)
            {
                var info = @">{0} - {1} at ({2},{3})
-Health points = {4}
-Attack points = {5}
-Defense points = {6}
-Energy points = {7}
-Range = {8}";
                return string.Format(info, this.Name, this.GetType().Name, this.X, this.Y,
                    this.HealthPoints, this.AttackPoints, this.DefensePoints, this.EnergyPoints, this.Range);
            }
            else
            {
                var info = @">{0} - {1} at ({2},{3})
(Dead)";
                return string.Format(info, this.Name, this.GetType().Name, this.X, this.Y);
            }
        }
    }
}
