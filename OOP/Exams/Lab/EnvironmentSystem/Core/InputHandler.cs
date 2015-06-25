using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnvironmentSystem.Interfaces;

namespace EnvironmentSystem.Core
{
    public class InputHandler: IController
    {
        public event EventHandler Pause;
        public void ProcessInput()
        {
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);

                if (key.Key == ConsoleKey.Spacebar)
                {
                    if (this.Pause != null)
                    {
                        this.Pause(this, EventArgs.Empty);                        
                    }
                }
            }
        }
    }
}
