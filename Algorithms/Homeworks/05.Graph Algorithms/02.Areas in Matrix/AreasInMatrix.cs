namespace _02.Areas_in_Matrix
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    class AreasInMatrix
    {
        static void Main(string[] args)
        {
            var rows = int.Parse(Regex.Match(Console.ReadLine(), @".*(\d).*").Groups[1].ToString());
            var field = new List<string>();
            for (int i = 0; i < rows; i++)
            {
                field.Add(Console.ReadLine());
            }

            var cols = field[0].Length;
            var visited = new bool[rows, cols];
            var areas = new Dictionary<char, int>();

            var nextCell = FindNextNotVisitedCell(field, visited);
            while (nextCell != null)
            {
                var que = new Queue<Cell>();
                que.Enqueue(nextCell);
                if (!areas.ContainsKey(nextCell.Symbol))
                {
                    areas.Add(nextCell.Symbol, 0);
                }

                areas[nextCell.Symbol]++;

                while (que.Count != 0)
                {
                    var currCell = que.Dequeue();
                    visited[currCell.X, currCell.Y] = true;

                    // Up
                    if (IsValidCell(currCell.X - 1, currCell.Y, nextCell.Symbol, field, visited))
                    {
                        que.Enqueue(new Cell(currCell.X - 1, currCell.Y, field[currCell.X - 1][currCell.Y]));
                    }

                    // Right
                    if (IsValidCell(currCell.X, currCell.Y + 1, nextCell.Symbol, field, visited))
                    {
                        que.Enqueue(new Cell(currCell.X, currCell.Y + 1, field[currCell.X][currCell.Y + 1]));
                    }

                    // Down
                    if (IsValidCell(currCell.X + 1, currCell.Y, nextCell.Symbol, field, visited))
                    {
                        que.Enqueue(new Cell(currCell.X + 1, currCell.Y, field[currCell.X + 1][currCell.Y]));
                    }

                    // Left
                    if (IsValidCell(currCell.X, currCell.Y - 1, nextCell.Symbol, field, visited))
                    {
                        que.Enqueue(new Cell(currCell.X, currCell.Y - 1, field[currCell.X][currCell.Y - 1]));
                    }
                }

                nextCell = FindNextNotVisitedCell(field, visited);
            }

            Console.WriteLine("Areas: {0}", areas.Sum(a => a.Value));
            foreach (var area in areas)
            {
                Console.WriteLine("Letter '{0}' -> {1}", area.Key, area.Value);
            }

        }

        private static bool IsValidCell(int x, int y, char symbol, List<string> field, bool[,] visited)
        {
            if (x >= 0 &&
                y >= 0 &&
                x < visited.GetLength(0) &&
                y < visited.GetLength(1) &&
                field[x][y] == symbol &&
                visited[x, y] == false)
            {
                return true;
            }

            return false;
        }

        private static Cell FindNextNotVisitedCell(List<string> field, bool[,] visited)
        {
            for (int i = 0; i < visited.GetLength(0); i++)
            {
                for (int j = 0; j < visited.GetLength(1); j++)
                {
                    if (visited[i, j] == false)
                    {
                        return new Cell(i, j, field[i][j]);
                    }
                }
            }

            return null;
        }
    }

    class Cell
    {
        public int X { get; set; }

        public int Y { get; set; }

        public char Symbol { get; set; }

        public Cell(int x, int y, char symbol)
        {
            this.X = x;
            this.Y = y;
            this.Symbol = symbol;
        }
    }
}
