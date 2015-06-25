using System.Collections.Generic;
using EnvironmentSystem.Models.DataStructures;

namespace EnvironmentSystem.Models.Objects
{
    public class Explosion : EnvironmentObject
    {
        private int lifeDuration;

        public Explosion(int x, int y, int width, int height) : base(x, y, width, height)
        {
            this.lifeDuration = 2;
            this.ImageProfile = this.GenerateImageProfile();
            this.CollisionGroup = CollisionGroup.Explosion;
        }

        protected virtual char[,] GenerateImageProfile()
        {
            return new char[,] { { '&' } };
        }

        public override void Update()
        {
            this.lifeDuration--;

            if (this.lifeDuration <= 0)
            {
                this.Exists = false;
            }
        }

        public override void RespondToCollision(CollisionInfo collisionInfo)
        {
            
        }

        public override IEnumerable<EnvironmentObject> ProduceObjects()
        {
            return new EnvironmentObject[0];
        }
    }
}