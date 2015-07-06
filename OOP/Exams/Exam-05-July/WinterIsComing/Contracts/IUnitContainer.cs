namespace WinterIsComing.Contracts
{
    using System.Collections.Generic;

    public interface IUnitContainer
    {
        IEnumerable<IUnit> GetUnitsInRange(int x, int y, int range);

        void Add(IUnit unit);

        void Remove(IUnit unit);

        void Move(IUnit unit, int newX, int newY);
    }
}
