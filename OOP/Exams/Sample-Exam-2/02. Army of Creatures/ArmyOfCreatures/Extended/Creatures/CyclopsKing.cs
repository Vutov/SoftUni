using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArmyOfCreatures.Extended.Specialties;
using ArmyOfCreatures.Logic.Creatures;
using ArmyOfCreatures.Logic.Specialties;

namespace ArmyOfCreatures.Extended.Creatures
{
    public class CyclopsKing: Creature
    {
        private const int DefaultCyclopsKingAttack = 17;
        private const int DefaultCyclopsKingDefense = 13;
        private const int DefaultCyclopsKingHealth = 70;
        private const decimal DefaultCyclopsKingDamage = 18;
        private const int CyclopsKingAttackWhenSkipped = 3;
        private const int CyclopsKingDoubleAttackWhenAttackingRounds = 4;
        private const int CyclopsKingDoubleAttackRounds = 1;

        public CyclopsKing()
            : base(DefaultCyclopsKingAttack, DefaultCyclopsKingDefense, DefaultCyclopsKingHealth, DefaultCyclopsKingDamage)
        {
            this.AddSpecialty(new AddAttackWhenSkip(CyclopsKingAttackWhenSkipped));
            this.AddSpecialty(new DoubleAttackWhenAttacking(CyclopsKingDoubleAttackWhenAttackingRounds));
            this.AddSpecialty(new DoubleDamage(CyclopsKingDoubleAttackRounds));
        }
    }
}
