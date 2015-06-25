namespace EnvironmentSystem.Interfaces
{
    using EnvironmentSystem.Models.DataStructures;

    public interface IRenderable
    {
        Rectangle Bounds { get; }

        char[,] ImageProfile { get; }
    }
}
