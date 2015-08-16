namespace VehicleParkSystem
{
    using System.Globalization;
    using System.Threading;
    using Core;
    using UI;

    public static class ApplicationMain
    {
        public static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            
            var userInterface = new UserInterface();
            var commandHandler = new CommandHandler();
            var engine = new Engine(commandHandler, userInterface);

            engine.Run();
        }
    }
}