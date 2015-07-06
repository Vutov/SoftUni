namespace WinterIsComing.Contracts
{
    using System.Collections.Generic;

    public interface IEngine
    {
        void Start();

        void Stop();

        void InsertUnit(IUnit unit);

        void RemoveUnit(IUnit unit);

        IEnumerable<IUnit> Units { get; } 

        IUnitContainer UnitContainer { get; }

        IOutputWriter OutputWriter { get; }

        IUnitEffector UnitEffector { get; }
    }
}
