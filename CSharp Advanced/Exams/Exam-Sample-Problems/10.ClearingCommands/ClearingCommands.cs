using System;
using System.Collections.Generic;
using System.Linq;

namespace _10.ClearingCommands
{
    class ClearingCommands
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            var field = new List<List<char>>();
            var nonClearSymbols = new[] { '>', '<', 'v', '^' };

            while (!input.Equals("END"))
            {
                field.Add(input.ToCharArray().ToList());

                input = Console.ReadLine();
            }

            for (int row = 0; row < field.Count; row++)
            {
                for (int col = 0; col < field[row].Count; col++)
                {
                    char currentSymbol = field[row][col];
                    var currentCol = col;
                    var currentRow = row;
                    var nextChar = ' ';
                    switch (currentSymbol)
                    {
                        case '>':
                            currentCol++;
                            if (currentCol < field[row].Count)
                            {
                                nextChar = field[row][currentCol];
                                while (!nonClearSymbols.Contains(nextChar))
                                {
                                    field[row][currentCol] = ' ';
                                    if (currentCol < field[row].Count - 1)
                                    {
                                        currentCol++;
                                        nextChar = field[row][currentCol];
                                    }
                                    else
                                    {
                                        break;
                                    }
                                }
                            }

                            break;
                        case '<':
                            currentCol--;
                            if (currentCol >= 0)
                            {
                                nextChar = field[row][currentCol];
                                while (!nonClearSymbols.Contains(nextChar))
                                {
                                    field[row][currentCol] = ' ';
                                    if (currentCol > 0)
                                    {
                                        currentCol--;
                                        nextChar = field[row][currentCol];
                                    }
                                    else
                                    {
                                        break;
                                    }
                                }
                            }

                            break;
                        case '^':
                            currentRow--;
                            if (currentRow >= 0)
                            {
                                nextChar = field[currentRow][col];
                                while (!nonClearSymbols.Contains(nextChar))
                                {
                                    field[currentRow][col] = ' ';
                                    if (currentRow > 0)
                                    {
                                        currentRow--;
                                        nextChar = field[currentRow][col];
                                    }
                                    else
                                    {
                                        break;
                                    }
                                }
                            }

                            break;
                        case 'v':
                            currentRow++;
                            if (currentRow < field.Count - 1)
                            {
                                nextChar = field[currentRow][col];
                                while (!nonClearSymbols.Contains(nextChar))
                                {
                                    field[currentRow][col] = ' ';
                                    if (currentRow < field.Count - 1)
                                    {
                                        currentRow++;
                                        nextChar = field[currentRow][col];
                                    }
                                    else
                                    {
                                        break;
                                    }
                                }
                            }

                            break;
                    }
                }
            }

            foreach (var row in field)
            {
                var line = string.Join("", row);
                line = line.Replace(">", "&gt;");
                line = line.Replace("<", "&lt;");
                Console.WriteLine("<p>{0}</p>", line);
            }
        }
    }
}
