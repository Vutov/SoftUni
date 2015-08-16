namespace VehicleParkSystem.UI
{
    using System;
    using Interfaces;

    public struct UserInterface : IUserInterface
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }

        public void WriteLine(string format, params string[] args)
        {
            Console.WriteLine(format, args);
        }
    }
}
