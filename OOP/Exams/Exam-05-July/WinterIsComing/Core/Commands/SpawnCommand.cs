namespace WinterIsComing.Core.Commands
{
    using System;
    using Contracts;
    using Models;

    public class SpawnCommand : AbstractCommand
    {
        public SpawnCommand(IEngine engine) 
            : base(engine)
        {
        }

        public override void Execute(string[] commandArgs)
        {
            UnitType unitType = (UnitType) Enum.Parse(
                typeof(UnitType), commandArgs[1]);
            string unitName = commandArgs[2];
            int x = int.Parse(commandArgs[3]);
            int y = int.Parse(commandArgs[4]);

            var unit = UnitFactory.Create(unitType, unitName, x, y);

            this.Engine.InsertUnit(unit);
            this.Engine.UnitContainer.Add(unit);
            this.Engine.OutputWriter.Write(string.Format(
                GlobalMessages.UnitSpawned, unitName));
        }
    }
}
