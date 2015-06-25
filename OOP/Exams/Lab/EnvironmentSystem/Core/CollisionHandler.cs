namespace EnvironmentSystem.Core
{
    using System.Collections.Generic;

    using EnvironmentSystem.Interfaces;
    using EnvironmentSystem.Models;
    using EnvironmentSystem.Models.DataStructures;

    public class CollisionHandler : ICollisionHandler
    {
        private readonly QuadTree objectsInPlane;

        public CollisionHandler(int worldWidth, int worldHeight)
        {
            this.objectsInPlane = new QuadTree(0, new Rectangle(0, 0, worldWidth, worldHeight));
        }

        public void HandleCollisions(IEnumerable<ICollidable> collidableObjects)
        {
            foreach (var collidable in collidableObjects)
            {
                this.objectsInPlane.Insert(collidable);
            }

            foreach (var collidable in collidableObjects)
            {
                var candidateCollisionItems = this.objectsInPlane
                    .GetItemsInRange(new List<ICollidable>(), collidable.Bounds);

                foreach (var candidateCollider in candidateCollisionItems)
                {
                    if (Rectangle.Intersects(collidable.Bounds, candidateCollider.Bounds)
                        && candidateCollider != collidable)
                    {
                        var collisionInfo = new CollisionInfo(candidateCollider);
                        collidable.RespondToCollision(collisionInfo);
                    }
                }
            }

            this.objectsInPlane.Clear();
        }
    }
}
