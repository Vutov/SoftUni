namespace WinterIsComing.Core
{
    using Commands;

    public class ExtendedCommandDispatcher: CommandDispatcher
    {
        public override void SeedCommands()
        {
            base.SeedCommands();
            this.commandsByName["toggle-effector"] = new ToggleEffectorCommand(this.Engine);
        }
    }
}
