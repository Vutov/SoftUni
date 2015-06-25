namespace EnvironmentSystem.Interfaces
{
    using System.Collections.Generic;

    public interface ICollisionHandler
    {
        void HandleCollisions(IEnumerable<ICollidable> collidableObjects);
    }
}
