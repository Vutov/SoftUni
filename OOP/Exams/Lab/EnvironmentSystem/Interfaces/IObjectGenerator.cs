namespace EnvironmentSystem.Interfaces
{
    using System.Collections.Generic;

    public interface IObjectGenerator<T>
    {
        IEnumerable<T> SeedInitialObjects();

        IEnumerable<T> GenerateNextObjects();
    }
}
