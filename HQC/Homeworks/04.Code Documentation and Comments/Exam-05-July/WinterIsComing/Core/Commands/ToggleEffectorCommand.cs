namespace WinterIsComing.Core.Commands
{
    using System.Linq;
    using Contracts;

    public class ToggleEffectorCommand : AbstractCommand
    {
        public ToggleEffectorCommand(IEngine engine) 
            : base(engine)
        {
        }

        public override void Execute(string[] commandArgs)
        {
            var liveUnits = this.Engine.Units
                .Where(u => u.HealthPoints > 0);

            this.Engine.UnitEffector.ApplyEffect(liveUnits);
        }
    }
}
