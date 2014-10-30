using System;

class BitShifting
{
    static void Main(string[] args)
    {
        long number = long.Parse(Console.ReadLine());
        int n = int.Parse(Console.ReadLine()); //number of shieves
        for (int i = 0; i < n; i++)
        {
            long sieve = long.Parse(Console.ReadLine());
            number = number & ~sieve; // 0 is turned to 1, 1 and 1 == 1
        } // while 0 and 1 is 0, so only 1 are passed.
        string siftedCount = Convert.ToString(number, 2);
        int count = 0;
        foreach (char digit in siftedCount)
        {
            if (digit == '1')
            {
                count++;
            }
        }
        Console.WriteLine(count);
    }
}