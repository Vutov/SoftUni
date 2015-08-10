namespace IssueTracker.Core
{
    using System;
    using Interfaces;
    using Models;

    public class Engine : IEngine
    {
        private readonly Dispatcher dispatcher;

        public Engine(Dispatcher dispatcher)
        {
            this.dispatcher = dispatcher;
        }

        public Engine()
            : this(new Dispatcher())
        {
        }

        public void Run()
        {
            var commandLine = Console.ReadLine();
            while (commandLine != null && commandLine != "end")
            {
                commandLine = commandLine.Trim();
                try
                {
                    var endpoint = new Endpoint(commandLine);
                    var viewResult = this.dispatcher.DispatchAction(endpoint);
                    Console.WriteLine(viewResult);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                commandLine = Console.ReadLine();
            }
        }
    }
}