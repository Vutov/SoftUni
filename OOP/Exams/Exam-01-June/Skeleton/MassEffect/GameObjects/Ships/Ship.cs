using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MassEffect.Engine;
using MassEffect.GameObjects.Enhancements;
using MassEffect.GameObjects.Locations;
using MassEffect.GameObjects.Projectiles;
using MassEffect.Interfaces;

namespace MassEffect.GameObjects.Ships
{
    public abstract class Ship : IStarship
    {
        private IList<Enhancement> enhancements = new List<Enhancement>();
        private string name;

        protected Ship(string name, int health, int shield, int damage, int fuel, StarSystem location)
        {
            this.Name = name;
            this.Health = health;
            this.Shields = shield;
            this.Damage = damage;
            this.Fuel = fuel;
            this.Location = location;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (Validator.ValidName(value))
                {
                    this.name = value;
                }
            }
        }

        public int Health { get; set; }

        public int Shields { get; set; }

        public int Damage { get; set; }

        public double Fuel { get; set; }

        public StarSystem Location { get; set; }

        public int ProjectilesFired { get; set; }

        public IEnumerable<Enhancement> Enhancements
        {
            get
            {
                return this.enhancements;
            }
        }

        public void AddEnhancement(Enhancement enhancement)
        {
            this.enhancements.Add(enhancement);
            if (enhancement.DamageBonus != 0)
            {
                this.Damage += enhancement.DamageBonus;
            }

            if (enhancement.FuelBonus != 0)
            {
                this.Fuel += enhancement.FuelBonus;
            }

            if (enhancement.ShieldBonus != 0)
            {
                this.Shields += enhancement.ShieldBonus;
            }
        }

        public abstract IProjectile ProduceAttack();

        public virtual void RespondToAttack(IProjectile attack)
        {
            attack.Hit(this);

            if (this.Health <= 0)
            {
                this.Health = 0;
                Console.WriteLine(Messages.ShipDestroyed, this.Name);
            }

            if (this.Shields < 0)
            {
                this.Shields = 0;
            }
        }

        public override string ToString()
        {
            return string.Format("--{0} - {1}", this.Name, GetType().Name);
        }
    }
}
