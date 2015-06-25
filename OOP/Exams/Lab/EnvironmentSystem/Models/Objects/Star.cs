using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnvironmentSystem.Core.Generator;
using EnvironmentSystem.Models.DataStructures;

namespace EnvironmentSystem.Models.Objects
{
    class Star : EnvironmentObject
    {
        private readonly Random rngJesus;

        public Star(int x, int y, int width, int height) : base(x, y, width, height)
        {
            this.rngJesus = new Random();
            this.ImageProfile = this.GenerateImageProfile();
            this.CollisionGroup = CollisionGroup.Star;
        }

        private int FlickerCounter { get; set; }

        protected virtual char[,] GenerateImageProfile()
        {
            var imageNum = this.rngJesus.Next(0, 3);
            switch (imageNum)
            {
                case 0:
                    return new char[,] { { 'O' } };
                case 1:
                    return new char[,] { { '@' } };
                case 2:
                    return new char[,] { { '0' } };
                default:
                    return new char[,] { { '0' } };
            }
        }

        public override void Update()
        {
            if (this.FlickerCounter == 9)
            {
                this.ImageProfile = this.GenerateImageProfile();
                this.FlickerCounter = 0;
            }
            else
            {
                this.FlickerCounter++;
            }
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
