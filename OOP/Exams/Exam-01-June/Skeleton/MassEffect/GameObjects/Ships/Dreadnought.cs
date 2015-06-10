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
    public class Dreadnought : Ship
    {
        public Dreadnought(string name, StarSystem location)
            : base(name, 200, 300, 150, 700, location)
        {

        }

        public override IProjectile ProduceAttack()
        {
            var damage = this.Shields / 2 + this.Damage;
            var projectile = new Laser(damage);
            this.ProjectilesFired++;

            return projectile;
        }

        public override void RespondToAttack(IProjectile attack)
        {
            this.Shields += 50;

            attack.Hit(this);

            this.Shields -= 50;

            if (this.Health <= 0)
            {
                this.Health = 0;
                Console.WriteLine(Messages.ShipDestroyed, this.Name);
            }

            if (this.Shields <= 0)
            {
                this.Shields = 0;
            }
        }
    }
}
