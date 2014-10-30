using System;

class OddEvenSum
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine()); //numbers
        int twiceN = 2 * n;
        int sumOdd = new int();
        int sumEven = new int();
        for (int i = 1; i <= twiceN; i++)
        {
            if (i % 2 == 0) // even numbers
            {
                int number = int.Parse(Console.ReadLine());
                sumEven += number;
            }
            else // odd numbers
            {
                int number = int.Parse(Console.ReadLine());
                sumOdd += number;
            }
        }
        if (sumEven == sumOdd)
        {
            Console.WriteLine("Yes, sum=" + sumEven);
        }
        else
        {
            Console.WriteLine("No, diff=" + Math.Abs(sumEven - sumOdd));
        }
    }
}