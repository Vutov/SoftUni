namespace WinterIsComing.Core
{
    using System;
    using System.Collections.Generic;
    using Commands;
    using Contracts;

    public class CommandDispatcher : ICommandDispatcher
    {
        protected readonly IDictionary<string, ICommand> commandsByName;

        public CommandDispatcher()
        {
            this.commandsByName = new Dictionary<string, ICommand>();
        }

        public IEngine Engine { get; set; }

        public virtual void DispatchCommand(string[] commandArgs)
        {
            string commandName = commandArgs[0];
            if (!this.commandsByName.ContainsKey(commandName))
            {
                throw new NotSupportedException(
                    "Command is not supported by engine");
            }

            var command = this.commandsByName[commandName];
            command.Execute(commandArgs);
        }

        public virtual void SeedCommands()
        {
            this.commandsByName["spawn"] = new SpawnCommand(this.Engine);
            this.commandsByName["fight"] = new FightCommand(this.Engine);
            this.commandsByName["move"] = new MoveCommand(this.Engine);
            this.commandsByName["status"] = new StatusCommand(this.Engine);
            this.commandsByName["winter-came"] = new WinterCameCommand(this.Engine);
         }
    }
}
