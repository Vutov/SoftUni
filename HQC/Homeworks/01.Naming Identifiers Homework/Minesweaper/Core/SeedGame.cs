namespace Application2.Core
{
    using System;
    using System.Collections.Generic;

    public class SeedGame
    {
        public static char[,] CreateGameField()
        {
            const int BoardRows = 5;
            const int BoardColumns = 10;
            var board = new char[BoardRows, BoardColumns];
            for (int i = 0; i < BoardRows; i++)
            {
                for (int j = 0; j < BoardColumns; j++)
                {
                    board[i, j] = '?';
                }
            }

            return board;
        }

        public static char[,] SetBoard()
        {
            const int Rows = 5;
            const int Cols = 10;
            const int MaxBombs = 15;
            var rng = new Random();

            var playField = new char[Rows, Cols];

            for (int row = 0; row < Rows; row++)
            {
                for (int col = 0; col < Cols; col++)
                {
                    playField[row, col] = '-';
                }
            }

            var bombs = new List<int>();
            while (bombs.Count < MaxBombs)
            {
                int nextBombIndex = rng.Next(50);
                if (!bombs.Contains(nextBombIndex))
                {
                    bombs.Add(nextBombIndex);
                }
            }

            foreach (int bombIndex in bombs)
            {
                int bombCol = bombIndex / Cols;
                int bombRow = bombIndex % Cols;
                if (bombRow == 0 && bombIndex != 0)
                {
                    bombCol--;
                    bombRow = Cols;
                }
                else
                {
                    bombRow++;
                }

                playField[bombCol, bombRow - 1] = '*';
            }

            return playField;
        }

        public static void GetSurroundingBombsCount(char[,] field)
        {
            int rows = field.GetLength(0);
            int cols = field.GetLength(1);

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    if (field[row, col] != '*')
                    {
                        char surroundingBombs = GetNumberOfBombs(field, row, col);
                        field[row, col] = surroundingBombs;
                    }
                }
            }
        }

        public static char GetNumberOfBombs(char[,] field, int row, int col)
        {
            int numberOfBombs = 0;
            int fieldRows = field.GetLength(0);
            int fieldCols = field.GetLength(1);

            if (row - 1 >= 0)
            {
                if (field[row - 1, col] == '*')
                {
                    numberOfBombs++;
                }
            }

            if (row + 1 < fieldRows)
            {
                if (field[row + 1, col] == '*')
                {
                    numberOfBombs++;
                }
            }

            if (col - 1 >= 0)
            {
                if (field[row, col - 1] == '*')
                {
                    numberOfBombs++;
                }
            }

            if (col + 1 < fieldCols)
            {
                if (field[row, col + 1] == '*')
                {
                    numberOfBombs++;
                }
            }

            if ((row - 1 >= 0) && (col - 1 >= 0))
            {
                if (field[row - 1, col - 1] == '*')
                {
                    numberOfBombs++;
                }
            }

            if ((row - 1 >= 0) && (col + 1 < fieldCols))
            {
                if (field[row - 1, col + 1] == '*')
                {
                    numberOfBombs++;
                }
            }

            if ((row + 1 < fieldRows) && (col - 1 >= 0))
            {
                if (field[row + 1, col - 1] == '*')
                {
                    numberOfBombs++;
                }
            }

            if ((row + 1 < fieldRows) && (col + 1 < fieldCols))
            {
                if (field[row + 1, col + 1] == '*')
                {
                    numberOfBombs++;
                }
            }

            return char.Parse(numberOfBombs.ToString());
        }
    }
}
