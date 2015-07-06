namespace WinterIsComing.Core.Commands
{
    using Contracts;

    public class WinterCameCommand : AbstractCommand
    {
        public WinterCameCommand(IEngine engine)
            : base(engine)
        {
        }

        public override void Execute(string[] commandArgs)
        {
            this.Engine.Stop();
        }
    }
}
