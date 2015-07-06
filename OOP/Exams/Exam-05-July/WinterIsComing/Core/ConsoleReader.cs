namespace WinterIsComing.Core
{
    using System;
    using Contracts;

    public class ConsoleReader : IInputReader
    {
        public string ReadNextLine()
        {
            return Console.ReadLine();
        }
    }
}
