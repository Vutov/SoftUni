using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MassEffect.GameObjects.Enhancements;
using MassEffect.GameObjects.Locations;
using MassEffect.GameObjects.Projectiles;
using MassEffect.Interfaces;

namespace MassEffect.GameObjects.Ships
{
    public class Cruiser: Ship
    {
        public Cruiser(string name, StarSystem location) : base(name, 100, 100, 50, 300, location)
        {

        }

        public override IProjectile ProduceAttack()
        {
            var projectile = new PenetrationShell(this.Damage);
            this.ProjectilesFired++;

            return projectile;
        }
    }
}
