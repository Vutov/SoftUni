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
    public class Frigate : Ship
    {
        public Frigate(string name, StarSystem location)
            : base(name, 60, 50, 30, 220, location)
        {

        }

        public override IProjectile ProduceAttack()
        {
            var projectile = new ShieldReaver(this.Damage);
            this.ProjectilesFired++;

            return projectile;
        }
    }
}
