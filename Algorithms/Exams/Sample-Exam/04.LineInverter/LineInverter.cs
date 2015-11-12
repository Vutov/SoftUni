using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.LineInverter
{
    class LineInverter
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var field = new List<List<char>>();
            for (int i = 0; i < n; i++)
            {
                var row = Console.ReadLine().ToCharArray().ToList();
                field.Add(row);
            }

            var inverts = 0;
            while (true)
            {
                // Row search
                var bestRow = -1;
                var bestNumInRow = 0;
                for (int row = 0; row < field.Count; row++)
                {
                    var foundInRows = 0;
                    for (int col = 0; col < field[row].Count; col++)
                    {
                        if (field[row][col] == 'W')
                        {
                            foundInRows++;
                        }
                    }

                    if (foundInRows > bestNumInRow)
                    {
                        bestNumInRow = foundInRows;
                        bestRow = row;
                    }
                }

                //Console.WriteLine(bestRow);

                // Col search
                var bestCol = -1;
                var bestNumInCol = 0;
                for (int col = 0; col < field.Count; col++)
                {
                    var foundInCols = 0;
                    for (int row = 0; row < field.Count; row++)
                    {
                        if (field[row][col] == 'W')
                        {
                            foundInCols++;
                        }
                    }

                    if (foundInCols > bestNumInCol)
                    {
                        bestNumInCol = foundInCols;
                        bestCol = col;
                    }
                }

                //Console.WriteLine(bestCol);

                if (bestCol == -1 && bestRow == -1)
                {
                    break;
                }

                if (bestNumInRow > bestNumInCol)
                {
                    //Console.WriteLine("Invert row " + bestRow);
                    InvertRow(field, bestRow);
                }
                else
                {
                    //Console.WriteLine("Invert col " + bestCol);
                    InvertCol(field, bestCol);
                }

                //Print(field);
                //Console.WriteLine();

                inverts++;
                if (inverts > n * n)
                {
                    inverts = -1;
                    break;
                }
            }

            Console.WriteLine(inverts);
        }

        private static void InvertCol(List<List<char>> field, int col)
        {
            for (int i = 0; i < field.Count; i++)
            {
                field[i][col] = Invert(field[i][col]);
            }
        }

        private static void InvertRow(List<List<char>> field, int row)
        {
            for (int i = 0; i < field.Count; i++)
            {
                field[row][i] = Invert(field[row][i]);
            }
        }

        private static char Invert(char c)
        {
            if (c == 'W')
            {
                return 'B';
            }

            return 'W';
        }

        private static void Print(List<List<char>> field)
        {
            for (int i = 0; i < field.Count; i++)
            {
                for (int j = 0; j < field[i].Count; j++)
                {
                    Console.Write(field[i][j]);
                }

                Console.WriteLine();
            }
        }
    }
}
