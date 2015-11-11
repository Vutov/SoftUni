using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Bridges
{
    class Bridges
    {
        static void Main(string[] args)
        {
            //var northSide = new List<int>() { 2, 5, 3, 3, 3, 1, 8, 2, 6, 7, 6 };
            //var southSide = new List<int>() { 1, 2, 5, 3, 4, 1, 7, 8, 2, 5, 6 };
            //var northSide = new List<int>() { 1 };
            //var southSide = new List<int>() { 1, 1, 1 };
            var northSide = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            var southSide = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            var field = new int[northSide.Count, southSide.Count];

            if (northSide[0] == southSide[0])
            {
                field[0, 0] = 1;
            }

            for (int col = 1; col < southSide.Count; col++)
            {
                var currValue = field[0, col - 1];
                if (northSide[0] == southSide[col])
                {
                    currValue++;
                }

                field[0, col] = currValue;
            }

            for (int row = 1; row < northSide.Count; row++)
            {
                var currValue = field[row - 1, 0];
                if (northSide[row] == southSide[0])
                {
                    currValue++;
                }

                field[row, 0] = currValue;
            }

            for (int row = 1; row < northSide.Count; row++)
            {
                for (int col = 1; col < southSide.Count; col++)
                {
                    var currValue = Math.Max(field[row - 1, col], field[row, col - 1]);
                    if (northSide[row] == southSide[col])
                    {
                        currValue++;
                    }

                    field[row, col] = currValue;
                }
            }


            //for (int i = 0; i < northSide.Count; i++)
            //{
            //    for (int j = 0; j < southSide.Count; j++)
            //    {
            //        Console.Write(field[i, j] + " ");
            //    }

            //    Console.WriteLine();
            //}

            Console.WriteLine(field.Cast<int>().Max());
        }
    }
}
