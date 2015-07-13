namespace WinterIsComing.Core
{
    using System;
    using System.Collections.Generic;
    using Contracts;
    using Exceptions;

    public class MatrixContainer : IUnitContainer
    {
        private readonly IUnit[,] unitMatrix;

        public MatrixContainer(int rows, int cols)
        {
            this.unitMatrix = new IUnit[rows, cols];
        }

        public IEnumerable<IUnit> GetUnitsInRange(int x, int y, int range)
        {
            this.ValidatePosition(x, y, GlobalMessages.InvalidPosition);
            
            int startRow = Math.Max(0, y - range);
            int endRow = Math.Min(this.unitMatrix.GetLength(0) - 1, y + range);
            int startCol = Math.Max(0, x - range);
            int endCol = Math.Min(this.unitMatrix.GetLength(1) - 1, x + range);

            var unitsInRange = new List<IUnit>();

            for (int row = startRow; row <= endRow; row++)
            {
                for (int col = startCol; col <= endCol; col++)
                {
                    var currentUnit = this.unitMatrix[row, col];
                    if (this.unitMatrix[row, col] != null)
                    {
                        unitsInRange.Add(currentUnit);
                    }
                }
            }

            return unitsInRange;
        }

        public void Add(IUnit unit)
        {
            this.ValidatePosition(unit.X, unit.Y, GlobalMessages.InvalidPosition);

            if (this.unitMatrix[unit.Y, unit.X] != null)
            {
                throw new GameException(string.Format(
                    "There is already a unit on position [{0},{1}]",
                    unit.X, unit.Y));
            }

            this.unitMatrix[unit.Y, unit.X] = unit;
        }

        public void Remove(IUnit unit)
        {
            this.ValidatePosition(unit.X, unit.Y, GlobalMessages.InvalidPosition);

            if (this.unitMatrix[unit.Y, unit.X] == null)
            {
                throw new GameException("Unit is not present in container");
            }

            this.unitMatrix[unit.Y, unit.X] = null;
        }

        public void Move(IUnit unit, int newX, int newY)
        {
            var unitInMatrix = this.unitMatrix[unit.Y, unit.X];
            if (unitInMatrix == null)
            {
                throw new InvalidPositionException("Unit is not present in container");
            }

            this.ValidatePosition(newX, newY, GlobalMessages.InvalidMove);
            if (this.unitMatrix[newY, newX] != null)
            {
                throw new GameException(string.Format(
                    "There is already a unit on position [{0},{1}]",
                    newX, newY));
            }

            this.unitMatrix[unit.Y, unit.X] = null;

            unit.X = newX;
            unit.Y = newY;
            this.unitMatrix[unit.Y, unit.X] = unit;
        }

        private void ValidatePosition(int x, int y, string errorMsg)
        {
            if (!(x >= 0 && x < this.unitMatrix.GetLength(1)) ||
                !(y >= 0 && y < this.unitMatrix.GetLength(0)))
            {
                throw new InvalidPositionException(errorMsg);
            }
        }
    }
}
