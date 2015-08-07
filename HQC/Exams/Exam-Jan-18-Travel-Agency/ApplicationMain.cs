namespace TravelAgency
{
    using System;
    using Core;
    using Interfaces;

    public class ApplicationMain
    {
        private static readonly ITicketCatalog Catalog = new TicketCatalog();
        private static readonly Engine ApplicationEngine = new Engine(Catalog);

        public static void Main()
        {
            var command = Console.ReadLine();
            while (command != null && command != "end")
            {
                command = command.Trim();
                if (command != string.Empty)
                {
                    var commandResult = ApplicationEngine.ExecuteCommand(command);
                    Console.WriteLine(commandResult);
                }

                command = Console.ReadLine();
            }
        }
    }
}