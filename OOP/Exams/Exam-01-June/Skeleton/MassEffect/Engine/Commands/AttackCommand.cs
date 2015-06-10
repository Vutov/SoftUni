using System;
using System.Linq;

namespace MassEffect.Engine.Commands
{
    using MassEffect.Interfaces;

    public class AttackCommand : Command
    {
        public AttackCommand(IGameEngine gameEngine)
            : base(gameEngine)
        {
        }

        public override void Execute(string[] commandArgs)
        {
            var ships = this.GameEngine.Starships.ToList();
            var attackerName = commandArgs[1];
            var attacker = ships.Find(s => s.Name == attackerName);
            if (attacker.Health <= 0)
            {
                Console.WriteLine(Messages.ShipAlreadyDestroyed);
                return;
            }

            var targetName = commandArgs[2];
            var target = ships.Find(s => s.Name == targetName);
            if (target.Health <= 0)
            {
                Console.WriteLine(Messages.ShipAlreadyDestroyed);
                return;
            }

            if (!attacker.Location.Name.Equals(target.Location.Name))
            {
                Console.WriteLine(Messages.NoSuchShipInStarSystem);
                return;
            }

            var attackProjectile = attacker.ProduceAttack();
            Console.WriteLine(Messages.ShipAttacked, attackerName, targetName);
            target.RespondToAttack(attackProjectile);
        }
    }
}
