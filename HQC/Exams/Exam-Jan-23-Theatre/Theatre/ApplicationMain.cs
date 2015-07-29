namespace Theatre
{
    using System;
    using System.Globalization;
    using System.Threading;
    using Core;

    public class ApplicationMain
    {
        private static readonly Engine ApplicationEngine = new Engine();

        public static void Main()
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("vi-VN");

            var command = Console.ReadLine();
            while (command != null && command != "end")
            {
                if (!string.IsNullOrEmpty(command))
                {
                    ProcessCommand(command);
                }

                command = Console.ReadLine();
            }
        }

        private static void ProcessCommand(string command)
        {
            var commandInfo = command.Split(new[] { '(', ',', ')' }, StringSplitOptions.RemoveEmptyEntries);
            var commandToExecute = commandInfo[0];
            string commandMessage;
            try
            {
                switch (commandToExecute)
                {
                    case "AddTheatre":
                        var teatere = commandInfo[1].Trim();
                        commandMessage = ApplicationEngine.ExecuteAddTheatreCommand(teatere);
                        break;
                    case "PrintAllTheatres":
                        commandMessage = ApplicationEngine.ExecutePrintAllTheatresCommand();
                        break;
                    case "AddPerformance":
                        var theatreName = commandInfo[1].Trim();
                        var performanceTitle = commandInfo[2].Trim();
                        var startDateTime = Convert.ToDateTime(commandInfo[3]);
                        var duration = TimeSpan.Parse(commandInfo[4]);
                        var price = decimal.Parse(commandInfo[5]);
                        commandMessage = ApplicationEngine.ExecuteAddPerformance(theatreName, performanceTitle, startDateTime, duration, price);
                        break;
                    case "PrintAllPerformances":
                        commandMessage = ApplicationEngine.ExecutePrintAllPerformancesCommand();
                        break;
                    case "PrintPerformances":
                        var printTeatreName = commandInfo[1].Trim();
                        commandMessage = ApplicationEngine.ExecutePrintPerformances(printTeatreName);
                        break;
                    default:
                        commandMessage = "Invalid command!";
                        break;
                }
            }
            catch (ApplicationException ex)
            {
                commandMessage = "Error: " + ex.Message;
            }

            Console.WriteLine(commandMessage);
        }
    }
}