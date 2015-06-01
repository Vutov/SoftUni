using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace P2
{
    class P2
    {
        static void Main(string[] args)
        {
            var coords = Regex.Split(Console.ReadLine(), @"\s+").Select(int.Parse).ToList();
            var word = Console.ReadLine();
            var shotData = Regex.Split(Console.ReadLine(), @"\s+").Select(int.Parse).ToList();

            var field = new char[coords[0], coords[1]];

            var rowReverser = 1;
            var currChar = 0;
            for (int row = coords[0] - 1; row >= 0; row--)
            {
                if (rowReverser % 2 == 0) // Even
                {
                    for (int col = 0; col < coords[1]; col++)
                    {
                        field[row, col] = word[currChar];
                        currChar++;
                        if (currChar > word.Length - 1)
                        {
                            currChar = 0;
                        }
                    }
                }
                else
                {
                    for (int j = coords[1] - 1; j >= 0; j--)
                    {
                        field[row, j] = word[currChar];
                        currChar++;
                        if (currChar > word.Length - 1)
                        {
                            currChar = 0;
                        }
                    }
                }

                rowReverser++;
            }

            var shotX = shotData[0];
            var shotY = shotData[1];
            var radius = shotData[2];

            for (int row = 0; row < coords[0]; row++)
            {
                for (int col = 0; col < coords[1]; col++)
                {
                    if (IsInsideCircle((double)row - shotX, (double)col - shotY, (double)radius))
                    {
                        field[row, col] = ' ';
                    }
                }
            }

            for (int row = 0; row < coords[0]; row++)
            {
                for (int col = 0; col < coords[1]; col++)
                {
                    if (IsInsideCircle((double)row - shotX, (double)col - shotY, (double)radius))
                    {
                        field[row, col] = ' ';
                    }
                }
            }

            for (int i = 0; i < 10; i++) // If multiple spaces after one an other;
            { 
                for (int row = coords[0] - 1; row >= 1; row--)
                {
                    for (int col = 0; col < coords[1]; col++)
                    {
                        if (field[row, col] == ' ')
                        {
                            var temp = field[row, col];
                            field[row, col] = field[row - 1, col];
                            field[row - 1, col] = temp;
                        }
                    }
                }
            }
            
            for (int row = 0; row < coords[0]; row++)
            {
                for (int col = 0; col < coords[1]; col++)
                {
                    Console.Write(field[row, col]);
                }

                Console.WriteLine();
            }
        }

        private static bool IsInsideCircle(double x, double y, double r)
        {
            // Using a^2 + b^2 = c^2;
            bool isInsideCircle = false;
            double radius = Math.Pow(r, 2);
            double num = (Math.Pow(x, 2) + Math.Pow(y, 2));
            if (num <= radius)
            {
                isInsideCircle = true;
            }

            return isInsideCircle;
        }
    }
}
