using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connecting_Cables
{
    class ConnectingCables
    {
        private static void Main(string[] args)
        {
            var side1 = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            //var side1 = new List<int> { 1, 2, 3 };
            var side2 = new List<int> { 2, 5, 3, 8, 7, 4, 6, 9, 1 };
            //var side2 = new List<int> { 1, 2, 3};

            var field = new int[side1.Count, side2.Count];

            if (side1[0] == side2[0])
            {
                field[0, 0] = 1;
            }

            for (int col = 1; col < field.GetLength(1); col++)
            {
                var value = field[0, col - 1];
                if (side1[0] == side2[col])
                {
                    value++;
                }

                field[0, col] = value;
            }

            for (int row = 1; row < field.GetLength(0); row++)
            {
                var value = field[row - 1, 0];
                if (side1[row] == side2[0])
                {
                    value++;
                }

                field[row, 0] = value;
            }

            for (int row = 1; row < field.GetLength(0); row++)
            {
                for (int col = 1; col < field.GetLength(1); col++)
                {
                    var value = Math.Max(field[row - 1, col], field[row, col - 1]);
                    if (side1[row] == side2[col])
                    {
                        value++;
                    }

                    field[row, col] = value;
                }
            }

            var x = field.GetLength(0) - 1;
            var y = field.GetLength(1) - 1;
            var pairs = new List<int>();
            while (x >= 0 && y >= 0)
            {
                if ((side1[x] == side2[y]))
                {
                    pairs.Add(side1[x]);
                    x--;
                    y--;
                }
                else if (field[x - 1, y] == field[x, y])
                {
                    x--;
                }
                else
                {
                    y--;
                }
            }

            pairs.Reverse();

            Console.WriteLine("Maximum pairs connected: {0}", field.Cast<int>().Max());
            Console.WriteLine("Connected pairs: {0}", string.Join(" ", pairs));
        }
    }
}
