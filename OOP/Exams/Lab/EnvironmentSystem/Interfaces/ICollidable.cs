namespace EnvironmentSystem.Interfaces
{
    using EnvironmentSystem.Models;
    using EnvironmentSystem.Models.DataStructures;

    public interface ICollidable
    {
        Rectangle Bounds { get; }

        CollisionGroup CollisionGroup { get; }

        void RespondToCollision(CollisionInfo collisionInfo);
    }
}