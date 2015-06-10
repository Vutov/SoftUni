namespace MassEffect.Interfaces
{
    public interface ICommandManager
    {
        IGameEngine Engine { get; set; }

        void ProcessCommand(string command);

        void SeedCommands();
    }
}
