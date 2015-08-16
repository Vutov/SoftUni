namespace VehicleParkSystem.Core
{
    using System.Collections.Generic;
    using System.Web.Script.Serialization;
    using Interfaces;

    public class Command : ICommand
    {
        public Command(string commandLine)
        {
            this.Name = commandLine.Substring(0, commandLine.IndexOf(' '));
            this.Parameters = new JavaScriptSerializer()
                .Deserialize<Dictionary<string, string>>(
                    commandLine.Substring(commandLine.IndexOf(' ') + 1));
        }

        public string Name { get; private set; }

        public IDictionary<string, string> Parameters { get; private set; }
    }
}