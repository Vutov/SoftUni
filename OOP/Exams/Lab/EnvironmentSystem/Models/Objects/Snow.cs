using System.Collections.Generic;
using EnvironmentSystem.Models.DataStructures;

namespace EnvironmentSystem.Models.Objects
{
    public class Snow : EnvironmentObject
    {
        public Snow(int x, int y, int width, int height) : base(x, y, width, height)
        {
            this.ImageProfile = this.GenerateImageProfile();
            this.CollisionGroup = CollisionGroup.Snow;
        }

        protected virtual char[,] GenerateImageProfile()
        {
            return new char[,] { { '.' } };
        }

        public override void Update()
        {
            
        }

        public override void RespondToCollision(CollisionInfo collisionInfo)
        {
            var hitObjectGroup = collisionInfo.HitObject.CollisionGroup;
            if (hitObjectGroup == CollisionGroup.Explosion)
            {
                this.Exists = false;
            }
        }

        public override IEnumerable<EnvironmentObject> ProduceObjects()
        {
            return new EnvironmentObject[0];
        }
    }
}