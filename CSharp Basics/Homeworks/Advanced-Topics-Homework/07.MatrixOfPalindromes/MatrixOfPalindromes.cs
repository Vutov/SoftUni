using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class MatrixOfPalindromes
{
    static void Main(string[] args)
    {
        int row = int.Parse(Console.ReadLine());
        int col = int.Parse(Console.ReadLine());

        for (int hight = 0; hight < row; hight++)
        {
            for (int width = 0; width < col; width++)
            {
                Console.Write("{0}{1}{0} ", (char)('a' + hight), (char)('a' + hight + width));
            }
            Console.WriteLine();
        }
    }
}
