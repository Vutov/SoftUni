namespace ArmyOfCreatures.Console.Commands
{
    using System;
    using Logic.Battles;

    public class ExitCommand : ICommand
    {
        public void ProcessCommand(IBattleManager battleManager, params string[] arguments)
        {
            Environment.Exit(0);
        }
    }
}
