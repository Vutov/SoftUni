namespace VehicleParkSystem.Core
{
    using System;
    using Interfaces;
    using UI;

    public class Engine : IEngine
    {
        private readonly CommandHandler commandHandler;
        private readonly IUserInterface userInterface;

        public Engine(CommandHandler commandHandler, IUserInterface userInterface)
        {
            this.commandHandler = commandHandler;
            this.userInterface = userInterface;
        }

        public Engine()
            : this(new CommandHandler(), new UserInterface())
        {
        }

        public void Run()
        {
            string commandLine = this.userInterface.ReadLine();
            while (commandLine != null && commandLine != "end")
            {
                commandLine = commandLine.Trim();
                if (!string.IsNullOrEmpty(commandLine))
                {
                    try
                    {
                        var command = new Command(commandLine);
                        var commandResult = this.commandHandler.Execute(command);
                        this.userInterface.WriteLine("{0}", commandResult);
                    }
                    catch (ArgumentException ex)
                    {
                        this.userInterface.WriteLine("{0}", ex.Message);
                    }
                    catch (InvalidOperationException ex)
                    {
                        this.userInterface.WriteLine("{0}", ex.Message);
                    }
                }

                commandLine = this.userInterface.ReadLine();
            }
        }
    }
}