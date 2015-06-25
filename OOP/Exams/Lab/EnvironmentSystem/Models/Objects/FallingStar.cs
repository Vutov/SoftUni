using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnvironmentSystem.Models.Objects
{
    class FallingStar : MovingObject
    {
        public FallingStar(int x, int y, int width, int height, Point direction)
            : base(x, y, width, height, direction)
        {
            this.ImageProfile = this.GenerateImageProfile();
            this.CollisionGroup = CollisionGroup.Star;
            this.DustFalling = false;
        }

        public bool DustFalling { get; set; }

        protected virtual char[,] GenerateImageProfile()
        {
            return new char[,] { { '@' } };
        }

        public override void RespondToCollision(CollisionInfo collisionInfo)
        {
            var hitObjectGroup = collisionInfo.HitObject.CollisionGroup;
            if (hitObjectGroup == CollisionGroup.Ground || hitObjectGroup == CollisionGroup.Explosion)
            {
                this.Exists = false;
            }
        }

        public override IEnumerable<EnvironmentObject> ProduceObjects()
        {
            if (!this.DustFalling)
            {
                this.DustFalling = true;

                if (this.Direction.X == 1)
                {
                    return new List<StarTailDust>()
                    {
                        new StarTailDust(this.Bounds.TopLeft.X - 1, this.Bounds.TopLeft.Y - 1, this.Bounds.Width,
                            this.Bounds.Height, this.Direction),
                        new StarTailDust(this.Bounds.TopLeft.X - 2, this.Bounds.TopLeft.Y - 2, this.Bounds.Width,
                            this.Bounds.Height, this.Direction),
                        new StarTailDust(this.Bounds.TopLeft.X - 3, this.Bounds.TopLeft.Y - 3, this.Bounds.Width,
                            this.Bounds.Height, this.Direction)
                    };
                }
                else if (this.Direction.X == 0)
                {
                    return new List<StarTailDust>()
                    {
                        new StarTailDust(this.Bounds.TopLeft.X, this.Bounds.TopLeft.Y - 1, this.Bounds.Width,
                            this.Bounds.Height, this.Direction),
                        new StarTailDust(this.Bounds.TopLeft.X, this.Bounds.TopLeft.Y - 2, this.Bounds.Width,
                            this.Bounds.Height, this.Direction),
                        new StarTailDust(this.Bounds.TopLeft.X, this.Bounds.TopLeft.Y - 3, this.Bounds.Width,
                            this.Bounds.Height, this.Direction)
                    };
                }
                else
                {
                    return new List<StarTailDust>()
                    {
                        new StarTailDust(this.Bounds.TopLeft.X + 1, this.Bounds.TopLeft.Y - 1, this.Bounds.Width,
                            this.Bounds.Height, this.Direction),
                        new StarTailDust(this.Bounds.TopLeft.X + 2, this.Bounds.TopLeft.Y - 2, this.Bounds.Width,
                            this.Bounds.Height, this.Direction),
                        new StarTailDust(this.Bounds.TopLeft.X + 3, this.Bounds.TopLeft.Y - 3, this.Bounds.Width,
                            this.Bounds.Height, this.Direction)
                    };
                }
            }

            return new EnvironmentObject[0];
        }
    }
}
