using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class OddEvenElements
{
    static void Main(string[] args)
    {
        string input = Console.ReadLine();
        //string input = "2 3 5 4 2 1";
        string[] digits = input.Split(' ');
        if (input == "")
        {
            digits = new string[0];
        }
        int len = digits.Length;

        decimal oddSum = 0;
        decimal oddMin = decimal.MaxValue;
        decimal oddMax = decimal.MinValue;
        decimal evenSum = 0;
        decimal evenMin = decimal.MaxValue;
        decimal evenMax = decimal.MinValue;

        for (int i = 1; i <= len; i++)
        {
            decimal number = decimal.Parse(digits[i - 1]);
            if (i % 2 == 0)//even
            {
                evenSum += number;
                evenMin = Math.Min(number, evenMin);
                evenMax = Math.Max(number, evenMax);
            }
            else//odd
            {
                oddSum += number;
                oddMin = Math.Min(number, oddMin);
                oddMax = Math.Max(number, oddMax);
            }
        }
        if (len == 0)
        {
            Console.WriteLine("OddSum=No, OddMin=No, OddMax=No, EvenSum=No, EvenMin=No, EvenMax=No");
        }
        else if (len == 1)
        {
            Console.WriteLine(
                "OddSum={0}, OddMin={1}, OddMax={2}, EvenSum=No, EvenMin=No, EvenMax=No",
                (double)oddSum, (double)oddMin, (double)oddMax);
        }
        else
        {
            Console.WriteLine(
                "OddSum={0}, OddMin={1}, OddMax={2}, EvenSum={3}, EvenMin={4}, EvenMax={5}",
                (double)oddSum, (double)oddMin, (double)oddMax,
                (double)evenSum, (double)evenMin, (double)evenMax);
        }
    }
}