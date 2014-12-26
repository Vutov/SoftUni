using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class CheatSheet
{
    static void Main(string[] args)
    {
        int rowSize = int.Parse(Console.ReadLine());
        int colSize = int.Parse(Console.ReadLine());
        long startRow = int.Parse(Console.ReadLine());
        long startCol = int.Parse(Console.ReadLine());

        for (int row = 0; row < rowSize; row++)
        {
            for (int col = 0; col < colSize; col++)
            {
                long currentNum = startRow * startCol;
                if (col == 0)
                {
                    Console.Write("{0}", currentNum);
                }
                else
                {
                    Console.Write(" {0}", currentNum);
                }
                startCol++;
            } 
            Console.WriteLine();
            startCol -= colSize;
            startRow++;
        }
    }
}