using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.PathsInCell
{
    class PathsInCell
    {
        private static char[,] lab =
        {
            {'s', ' ', ' ', ' ', ' ', ' '},
            {' ', '*', '*', ' ', '*', ' '},
            {' ', '*', '*', ' ', '*', ' '},
            {' ', '*', 'e', ' ', ' ', ' '},
            {' ', ' ', ' ', '*', ' ', ' '},
        };

        private static List<char> path = new List<char>();
        private static int totalPaths = 0;

        static void Main(string[] args)
        {
            FindPaths(0, 0, 's');
            Console.WriteLine("Total paths found: " + totalPaths);
        }

        private static void FindPaths(int x, int y, char dir)
        {
            if (x < 0 || y < 0 || x >= lab.GetLength(0) || y >= lab.GetLength(1))
            {
                // out of lab range
                return;
            }

            if (lab[x, y] == 'e')
            {
                // exit
                path.RemoveAt(0);
                path.Add(dir);
                totalPaths++;
                Console.WriteLine(string.Join("", path).ToUpper());
                return;
            }

            if (lab[x, y] == '*' || lab[x, y] == 'x')
            {
                // wall
                return;
            }

            lab[x, y] = 'x';
            path.Add(dir);

            FindPaths(x, y - 1, 'l'); // left
            FindPaths(x - 1, y, 'u'); // up
            FindPaths(x, y + 1, 'r'); // right
            FindPaths(x + 1, y, 'd'); // down


            lab[x, y] = ' ';
            path.RemoveAt(path.Count - 1);
        }
    }
}
