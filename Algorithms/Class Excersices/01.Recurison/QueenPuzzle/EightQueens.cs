using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueenPuzzle
{
    class EightQueens
    {
        private const int Size = 8;
        static readonly bool[,] chessboard = new bool[Size, Size];
        static readonly HashSet<int> blockedRows = new HashSet<int>();
        static readonly HashSet<int> blockedCols = new HashSet<int>();
        static readonly HashSet<int> blockedLeftDiagonals = new HashSet<int>();
        static readonly HashSet<int> blockedRightDiagonals = new HashSet<int>();
        private static int foundSolutions = 0;

        static void Main(string[] args)
        {
            PutQueens(0);
            Console.WriteLine();
            Console.WriteLine("Found solutions = " + foundSolutions);
        }

        static void PutQueens(int row)
        {
            if (row == Size)
            {
                PrintSolution();
            }
            else
            {
                for (int col = 0; col < Size; col++)
                {
                    if (CanPlaceQueen(row, col))
                    {
                        MarkAllBlockedPossitions(row, col);
                        PutQueens(row + 1);
                        UnmarkAllBlockedPossitions(row, col);
                    }
                }
            }
        }

        private static void UnmarkAllBlockedPossitions(int row, int col)
        {
            blockedRows.Remove(row);
            blockedCols.Remove(col);
            blockedLeftDiagonals.Remove(col - row);
            blockedRightDiagonals.Remove(row + col);
            chessboard[row, col] = false;
        }

        private static void MarkAllBlockedPossitions(int row, int col)
        {
            blockedRows.Add(row);
            blockedCols.Add(col);
            blockedLeftDiagonals.Add(col - row);
            blockedRightDiagonals.Add(row + col);
            chessboard[row, col] = true;
        }

        private static bool CanPlaceQueen(int row, int col)
        {
            if (blockedRows.Contains(row) ||
                blockedCols.Contains(col) ||
                blockedLeftDiagonals.Contains(col - row) ||
                blockedRightDiagonals.Contains(row + col))
            {
                return false;
            }

            return true;
        }

        private static void PrintSolution()
        {
            for (int row = 0; row < Size; row++)
            {
                for (int col = 0; col < Size; col++)
                {
                    if (chessboard[row, col])
                    {
                        Console.Write('Q');
                    }
                    else
                    {
                        Console.Write('-');
                    }
                }

                Console.WriteLine();
            }

            Console.WriteLine();
            foundSolutions++;
        }
    }
}
