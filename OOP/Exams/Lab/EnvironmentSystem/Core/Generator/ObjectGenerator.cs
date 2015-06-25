namespace EnvironmentSystem.Core.Generator
{
    using System;
    using System.Collections.Generic;

    using EnvironmentSystem.Models;
    using EnvironmentSystem.Models.Objects;
    using EnvironmentSystem.Interfaces;

    public class ObjectGenerator : IObjectGenerator<EnvironmentObject>
    {
        private const int ObjectsCount = 10;
        private const int StaticStarCount = 20;

        private readonly int worldWidth;
        private readonly int worldHeight;
        private readonly Random randomGenerator;

        public ObjectGenerator(int worldWidth, int worldHeight)
        {
            this.worldWidth = worldWidth;
            this.worldHeight = worldHeight;
            this.randomGenerator = new Random();
        }

        /// <summary>
        /// Adds objects only once to the passed collection. Should be used once.
        /// </summary>
        /// <param name="objects"></param>
        public IEnumerable<EnvironmentObject> SeedInitialObjects()
        {
            var generatedObjects = new List<EnvironmentObject>();
            for (int i = 0; i < StaticStarCount; i++)
            {
                int x = this.randomGenerator.Next(0, this.worldWidth);
                int y = this.randomGenerator.Next(0, 20);

            }

            generatedObjects.Add(new Ground(0, 25, 50, 2, '#'));

            return generatedObjects;
        }

        /// <summary>
        /// Adds the next portion of objects to the passed collection. Can be used many times.
        /// </summary>
        /// <param name="objects"></param>
        public IEnumerable<EnvironmentObject> GenerateNextObjects()
        {
            var generatedObjects = new List<EnvironmentObject>();
            for (int i = 0; i < ObjectsCount; i++)
            {
                int generateFlag = this.randomGenerator.Next(0, 5);
                int x = this.randomGenerator.Next(3, this.worldWidth - 3);
                int y = this.randomGenerator.Next(3, this.worldHeight / 2 - 3);

                if (generateFlag == 1)
                {
                    var envObject = new Snowflake(x, 1, 1, 1, new Point(0, 1));

                    generatedObjects.Add(envObject);
                }

                int StarFlag = this.randomGenerator.Next(0, 50);

                if (StarFlag == 1)
                {
                    var envObject = new Star(x, y, 1, 1);

                    generatedObjects.Add(envObject);
                }
                var direction = this.randomGenerator.Next(0, 3);

                if (StarFlag == 2)
                {
                    switch (direction)
                    {
                        case 0:
                            generatedObjects.Add(new FallingStar(x, y, 1, 1, new Point(1, 1)));
                            break;
                        case 1:
                            generatedObjects.Add(new FallingStar(x, y, 1, 1, new Point(-1, 1)));
                            break;
                        case 2:
                            generatedObjects.Add(new FallingStar(x, y, 1, 1, new Point(0, 1)));
                            break;
                    }
                }

                if (StarFlag == 3)
                {
                    switch (direction)
                    {
                        case 0:
                            generatedObjects.Add(new ExplodingStar(x, y, 1, 1, new Point(1, 1)));
                            break;
                        case 1:
                            generatedObjects.Add(new ExplodingStar(x, y, 1, 1, new Point(-1, 1)));
                            break;
                        case 2:
                            generatedObjects.Add(new FallingStar(x, y, 1, 1, new Point(0, 1)));
                            break;
                    }
                }
            }

            return generatedObjects;
        }
    }
}
