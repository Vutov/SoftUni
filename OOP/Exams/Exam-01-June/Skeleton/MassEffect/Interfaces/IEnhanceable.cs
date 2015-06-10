namespace MassEffect.Interfaces
{
    using System.Collections.Generic;

    using MassEffect.GameObjects.Enhancements;

    public interface IEnhanceable
    {
        IEnumerable<Enhancement> Enhancements { get; }

        void AddEnhancement(Enhancement enhancement);
    }
}
