using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using EnvironmentSystem.Interfaces;
using EnvironmentSystem.Models.Objects;

namespace EnvironmentSystem.Core
{
    class ExtendedEngine : Engine
    {
        protected readonly IController Controller;
        private bool isPaused;

        public ExtendedEngine(int worldWidth, int worldHeight, IObjectGenerator<EnvironmentObject> objectGenerator,
            ICollisionHandler collisionHandler, IRenderer renderer, IController controller)
            : base(worldWidth, worldHeight,
                objectGenerator, collisionHandler, renderer)
        {
            this.Controller = controller;
            this.Controller.Pause += (sender, args) =>
            {
                this.isPaused = !this.isPaused;
            };
        }

        protected override void Insert(EnvironmentObject obj)
        {
            if (obj != null)
            {
                this.objects.Add(obj);
            }
            else
            {
                throw new ArgumentNullException();
            }
        }

        protected override void ExecuteEnvironmentLoop()
        {
            Controller.ProcessInput();
            if (!isPaused)
            {
                base.ExecuteEnvironmentLoop();
            }
            else
            {
                Thread.Sleep(50);
            }

        }
    }
}
