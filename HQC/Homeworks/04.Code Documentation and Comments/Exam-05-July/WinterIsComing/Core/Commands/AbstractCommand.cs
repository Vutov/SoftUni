namespace WinterIsComing.Core.Commands
{
    using WinterIsComing.Contracts;

    public abstract class AbstractCommand : ICommand
    {
        protected AbstractCommand(IEngine engine)
        {
            this.Engine = engine;
        }

        public IEngine Engine { get; private set; }

        public abstract void Execute(string[] commandArgs);
    }
}
