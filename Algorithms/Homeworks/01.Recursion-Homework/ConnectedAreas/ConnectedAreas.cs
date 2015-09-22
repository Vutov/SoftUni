namespace ConnectedAreas
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ConnectedAreas
    {
//        private static readonly char[,] Lab =
//        {
//            {' ', ' ', ' ', '*', ' ', ' ', ' ', '*', ' '},
//            {' ', ' ', ' ', '*', ' ', ' ', ' ', '*', ' '},
//            {' ', ' ', ' ', '*', ' ', ' ', ' ', '*', ' '},
//            {' ', ' ', ' ', ' ', '*', ' ', '*', ' ', ' '},
//        };

        private static readonly char[,] Lab =
        {
            {'*', ' ', ' ', '*', ' ', ' ', ' ', '*', ' ', ' '},
            {'*', ' ', ' ', '*', ' ', ' ', ' ', '*', ' ', ' '},
            {'*', ' ', ' ', '*', '*', '*', '*', '*', ' ', ' '},
            {'*', ' ', ' ', '*', ' ', ' ', ' ', '*', ' ', ' '},
            {'*', ' ', ' ', '*', ' ', ' ', ' ', '*', ' ', ' '},
        };

        // Minor search optimization
        private static int lastRow = 0;
        private static int lastCol = 0;

        private static readonly Queue<Cell> CellsQue = new Queue<Cell>();
        private static readonly Dictionary<int, List<string>> Areas = new Dictionary<int, List<string>>();

        static void Main(string[] args)
        {
            FindAreas();
        }

        private static void FindAreas()
        {
            int totalAreas = 0;
            var cell = FindStartOfArea();
            while (cell != null)
            {
                var totalCells = CalculateArea(cell, 0);
                if (!Areas.ContainsKey(totalCells))
                {
                    Areas.Add(totalCells, new List<string>());
                }

                Areas[totalCells].Add(cell.X + ", " + cell.Y);
                cell = FindStartOfArea();
                totalAreas++;
            }

            Console.WriteLine("Total areas found: " + totalAreas);
            var num = 1;
            var orderedAreas = Areas.OrderByDescending(a => a.Key);
            foreach (var areaGroupe in orderedAreas)
            {
                foreach (var area in areaGroupe.Value)
                {
                    Console.WriteLine("Area #{0} at ({1}), size: {2}", num++, area, areaGroupe.Key);
                }
            }
        }

        private static int CalculateArea(Cell startingCell, int cellsInArea)
        {
            if (startingCell.X < 0 || 
                startingCell.Y < 0 ||
                startingCell.X >= Lab.GetLength(0) ||
                startingCell.Y >= Lab.GetLength(1))
            {
                // out of lab range
                return cellsInArea;
            }

            if (Lab[startingCell.X, startingCell.Y] != ' ')
            {
                // wall or visited
                return cellsInArea;
            }

            CellsQue.Enqueue(startingCell);
            Lab[startingCell.X, startingCell.Y] = 'v';
            cellsInArea++;

            while (CellsQue.Count > 0)
            {
                var curretnCell = CellsQue.Dequeue();

                cellsInArea = CalculateArea(new Cell(curretnCell.X + 0, curretnCell.Y - 1), cellsInArea);
                cellsInArea = CalculateArea(new Cell(curretnCell.X + 1, curretnCell.Y + 0), cellsInArea);
                cellsInArea = CalculateArea(new Cell(curretnCell.X + 0, curretnCell.Y + 1), cellsInArea);
                cellsInArea = CalculateArea(new Cell(curretnCell.X - 1, curretnCell.Y + 0), cellsInArea);
            }

            return cellsInArea;
        }

        private static Cell FindStartOfArea()
        {
            for (int row = lastRow; row < Lab.GetLength(0); row++)
            {
                for (int col = lastCol; col < Lab.GetLength(1); col++)
                {
                    if (Lab[row, col] == ' ')
                    {
                        lastRow = row;
                        lastCol = col;
                        return new Cell(row, col);
                    }
                }
            }

            return null;
        }

        private class Cell
        {
            public Cell(int x, int y)
            {
                this.X = x;
                this.Y = y;
            }

            public int X { get; private set; }

            public int Y { get; private set; }
        }
    }
}