namespace EnvironmentSystem.Core
{
    using System.Collections.Generic;
    using System.Threading;

    using EnvironmentSystem.Models.DataStructures;
    using EnvironmentSystem.Interfaces;
    using EnvironmentSystem.Models.Objects;

    public class Engine
    {
        protected const int LoopIntervalInMilliseconds = 200;

        protected readonly Rectangle worldBounds;
        protected readonly List<EnvironmentObject> objects;
        protected readonly IRenderer renderer;
        protected readonly IObjectGenerator<EnvironmentObject> objectGenerator;
        protected readonly ICollisionHandler collisionHandler;

        public Engine(int worldWidth, 
            int worldHeight, 
            IObjectGenerator<EnvironmentObject> objectGenerator,
            ICollisionHandler collisionHandler, 
            IRenderer renderer)
        {
            this.objects = new List<EnvironmentObject>();
            this.objectGenerator = objectGenerator;

            this.renderer = renderer;
            this.collisionHandler = collisionHandler;
            this.worldBounds = new Rectangle(0, 0, worldWidth, worldHeight);
        }

        public virtual void Run()
        {
            var initialObjects = this.objectGenerator.SeedInitialObjects();
            foreach (var initialObject in initialObjects)
            {
                this.Insert(initialObject);
            }

            while (true)
            {
                this.ExecuteEnvironmentLoop();
            }
        }

        protected virtual void ExecuteEnvironmentLoop()
        {
            var dynamicallyGeneratedObjects = this.objectGenerator.GenerateNextObjects();
            foreach (var dynamicallyGeneratedObject in dynamicallyGeneratedObjects)
            {
                this.Insert(dynamicallyGeneratedObject);
            }

            foreach (var envObj in this.objects)
            {
                envObj.Update();
            }

            this.collisionHandler.HandleCollisions(this.objects);
            this.ProcessObjectProduction();

            this.objects.RemoveAll(x => !x.Exists ||
                !Rectangle.Intersects(this.worldBounds, x.Bounds));

            foreach (var envObject in this.objects)
            {
                this.renderer.EnqueueForRendering(envObject);
            }

            this.renderer.RenderAll();

            Thread.Sleep(LoopIntervalInMilliseconds);

            this.renderer.ClearQueue();
        }

        protected virtual void Insert(EnvironmentObject obj)
        {
            this.objects.Add(obj);
        }

        private void ProcessObjectProduction()
        {
            List<EnvironmentObject> newObjects = new List<EnvironmentObject>();
            foreach (var envObject in this.objects)
            {
                var producedObjects = envObject.ProduceObjects();
                newObjects.AddRange(producedObjects);
            }

            foreach (var obj in newObjects)
            {
                this.Insert(obj);
            }
        }
    }
}
