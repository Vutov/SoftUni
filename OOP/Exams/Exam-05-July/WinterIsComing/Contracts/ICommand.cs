namespace WinterIsComing.Contracts
{
    public interface ICommand
    {
        IEngine Engine { get; }

        void Execute(string[] commandArgs);
    }
}
