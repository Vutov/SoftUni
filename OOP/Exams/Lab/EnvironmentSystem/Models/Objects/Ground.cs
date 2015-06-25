using System;

namespace EnvironmentSystem.Models.Objects
{
    using System.Collections.Generic;

    public class Ground : EnvironmentObject
    {
        private readonly char image;

        public Ground(int x, int y, int width, int height, char image)
            : base(x, y, width, height)
        {
            this.image = image;
            this.CollisionGroup = CollisionGroup.Ground;
            this.ImageProfile = this.GenerateImageProfile();   
        }

        protected virtual char[,] GenerateImageProfile()
        {
            char[,] image = new char[this.Bounds.Height, this.Bounds.Width];
            for (int row = 0; row < image.GetLength(0); row++)
            {
                for (int col = 0; col < image.GetLength(1); col++)
                {
                    image[row, col] = this.image;
                }
            }

            return image;
        }

        public override void Update()
        {   
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
