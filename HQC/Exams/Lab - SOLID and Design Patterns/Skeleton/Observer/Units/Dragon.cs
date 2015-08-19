namespace Skyrim.Units
{
    using System;
    using System.Collections.Generic;
    using Items;

    public class Dragon : Unit
    {
        private readonly ICollection<Warrior> attackers = new List<Warrior>();

        public Dragon(string name, int attackPoints, int healthPoints)
            : base(name, attackPoints, healthPoints)
        {
        }

        public override int HealthPoints
        {
            get
            {
                return base.HealthPoints;
            }

            set
            {
                if (this.HealthPoints != value)
                {
                    this.Notify();
                }

                base.HealthPoints -=value;
            }
        }

        public void Attach(Warrior warrior)
        {
            if (warrior == null)
            {
                throw new InvalidOperationException("Warrior cannot be null!");
            }

            this.attackers.Add(warrior);
        }

        public bool Detach(Warrior warrior)
        {
            if (warrior == null)
            {
                throw new InvalidOperationException("Warrior cannot be null!");
            }

            var removed = this.attackers.Remove(warrior);
            return removed;
        }

        private void Notify()
        {
            if (this.HealthPoints <= 0)
            {
                foreach (var attacker in this.attackers)
                {
                    attacker.Update(new Weapon(100000, 100000));
                }
            }
        }
    }
}
