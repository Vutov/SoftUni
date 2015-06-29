namespace ArmyOfCreatures.Console.Commands
{
    using Logic.Battles;

    public interface ICommand
    {
        void ProcessCommand(IBattleManager battleManager, params string[] arguments);
    }
}
