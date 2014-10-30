using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Pairs
{
    static void Main(string[] args)
    {
        string input = Console.ReadLine();
        //string input = "1 1 3 1 2 2 0 0";
        string[] digits = input.Split(' ');
        int len = digits.Length;
        //first two numbers;
        int prevPairSum = int.Parse(digits[0]) + int.Parse(digits[1]);
        int diff = new int();
        int maxDiff = new int();

        for (int i = 2; i < len - 1; i += 2)
        {
            int pairSum = int.Parse(digits[i]) + int.Parse(digits[i + 1]);
            diff = Math.Abs(prevPairSum - pairSum);
            if (diff > maxDiff)
	        {
		         maxDiff = diff;
	        }
            prevPairSum = pairSum;

        }
        if (diff != 0)
        {
            Console.WriteLine("No, maxdiff={0}", maxDiff);
        }
        else
        {
            Console.WriteLine("Yes, value={0}", prevPairSum);
        }
    }
}