namespace ArmyOfCreatures.Console.Commands
{
    using Logic.Battles;

    public interface ICommandManager
    {
        void ProcessCommand(string commandLine, IBattleManager battleManager);
    }
}