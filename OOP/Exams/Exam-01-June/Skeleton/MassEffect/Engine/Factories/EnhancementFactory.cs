using MassEffect.GameObjects.Enhancements;

namespace MassEffect.Engine.Factories
{
    using System;

    public class EnhancementFactory
    {
        public Enhancement Create(EnhancementType enhancementType)
        {
            switch (enhancementType)
            {
                case EnhancementType.ThanixCannon:
                    return new Enhancement("ThanixCannon", 0, 50, 0);
                case EnhancementType.KineticBarrier:
                    return new Enhancement("KineticBarrier", 100, 0, 0);
                case EnhancementType.ExtendedFuelCells:
                    return new Enhancement("ExtendedFuelCells", 0, 0, 200);
                default:
                    throw new NotSupportedException("Enchantment type not supported.");
            }
        }
    }
}
