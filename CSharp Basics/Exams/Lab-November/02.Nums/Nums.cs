using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Nums
{
    static void Main(string[] args)
    {
        int startNum = int.Parse(Console.ReadLine());
        int endNum = int.Parse(Console.ReadLine());

        for (int i = startNum; i <= endNum; i++)
        {
            if (i % 2 == 1)//Odd;
            {
                double num = Math.Pow(i, 2);
                Console.WriteLine("{0:F3}", num);
            }
            else//Even;
            {
                double num = Math.Sqrt(i);
                Console.WriteLine("{0:F3}", num);
            }
        }
    }
}
