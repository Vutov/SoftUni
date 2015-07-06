namespace WinterIsComing.Core.Commands
{
    using System;
    using System.Linq;

    using Contracts;

    public class MoveCommand : AbstractCommand
    {
        public MoveCommand(IEngine engine)
            : base(engine)
        {
        }

        public override void Execute(string[] commandArgs)
        {
            string name = commandArgs[1];
            int newX = int.Parse(commandArgs[2]);
            int newY = int.Parse(commandArgs[3]);

            var unit = this.Engine.Units
                .First(u => u.Name == name);

            if (Math.Abs(unit.X - newX) > 1 || 
                Math.Abs(unit.Y - newY) > 1)
            {
                throw new ArgumentOutOfRangeException("Units can move only 1 cell at a time");
            }

            this.Engine.UnitContainer.Move(unit, newX, newY);
            this.Engine.OutputWriter.Write(string.Format(
                "{0} has moved to ({1},{2})",
                name, newX, newY));
        }
    }
}
