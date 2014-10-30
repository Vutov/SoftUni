using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class HalfSum
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        int firstSum = 0;
        int secondSum = 0;
        for (int i = 0; i < n; i++)
        {
            int num = int.Parse(Console.ReadLine());
            firstSum += num;
        }
            
        for (int j = 0; j < n; j++)
        {
            int num = int.Parse(Console.ReadLine());
            secondSum += num;
        }
        if (firstSum == secondSum)
        {
            Console.WriteLine("Yes, sum={0}",firstSum);
        }
        else
        {
            int diff = Math.Abs(firstSum - secondSum);
            Console.WriteLine("No, diff={0}", diff);
        }
    }
}