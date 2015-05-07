using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
class BiggerNumber
{
    private static int GetMax(int n, int m)
    {
        if (m > n)
        {
            return m;
        }
        else
        {
            return n;
        }
    }
    static void Main(string[] args)
    {
        int firstNum = int.Parse(Console.ReadLine());
        int secondNum = int.Parse(Console.ReadLine());

        int max = GetMax(firstNum, secondNum);
        Console.WriteLine(max);
    }
}
