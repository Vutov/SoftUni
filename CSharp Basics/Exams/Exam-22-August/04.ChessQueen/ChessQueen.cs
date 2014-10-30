using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class ChessQueen
{
    static void Main(string[] args)
    {
        int size = int.Parse(Console.ReadLine());
        int distance = int.Parse(Console.ReadLine());
        //int size = 3;
        //int distance = 2;
        char letter = (char)('a' - 1); //First letter is a and loops start from 1;
        int count = 0;

        for (int x1 = 1; x1 <= size; x1++)
        {
            for (int y1 = 1; y1 <= size; y1++)
            {
                for (int x2 = 1; x2 <= size; x2++)
                {
                    for (int y2 = 1; y2 <= size; y2++)
                    {
                        if ((x1 == x2 && Math.Abs(y1 - y2) == distance + 1) || //Left and right
                            (y1 == y2 && Math.Abs(x1 - x2) == distance + 1) || //Up and down;
                            (Math.Abs(x1 - x2) == distance + 1 && Math.Abs(y1 - y2) == distance + 1))//Diagonals;
                        {
                            Console.WriteLine("{0}{1} - {2}{3}",
                                (char)(letter + x1), y1, (char)(letter + x2), y2);
                            count++;
                        }
                    }
                }
            }
        }
        if (count == 0)
        {
            Console.WriteLine("No valid positions");
        }

    }
}