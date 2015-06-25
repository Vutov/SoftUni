using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnvironmentSystem.Models.Objects
{
    class ExplodingStar : MovingObject
    {
        private int lifeDuration;

        public ExplodingStar(int x, int y, int width, int height, Point direction)
            : base(x, y, width, height, direction)
        {
            this.ImageProfile = this.GenerateImageProfile();
            this.CollisionGroup = CollisionGroup.Star;
            this.lifeDuration = 8;
        }

        protected virtual char[,] GenerateImageProfile()
        {
            return new char[,] { { 'X' } };
        }

        public override void Update()
        {
            base.Update();

            this.lifeDuration--;
            if (this.lifeDuration <= 0)
            {
                this.Exists = false;
            }
        }

        public override IEnumerable<EnvironmentObject> ProduceObjects()
        {
            if (!this.Exists)
            {
                var explosions = new List<Explosion>();

                for (int i = -2; i <= 2; i++)
                {
                    for (int j = -2; j <= 2; j++)
                    {
                        if (i == 0 && j == 0)
                        {
                            continue;
                        }

                        var explosion = new Explosion(this.Bounds.TopLeft.X + i, this.Bounds.TopLeft.Y + j,
                            this.Bounds.Width, this.Bounds.Height);
                        explosions.Add(explosion);

                    }
                }

                return explosions;
            }

            return new EnvironmentObject[0];
        }
    }
}
