using System;

class BitP
{
    static void Main(string[] args)
    {
        int n = 35;
        int p = 4;
        string binary = Convert.ToString(n, 2);
        int count = 0;
        foreach (char digit in binary)
        {
            count++;
            if (count == p)
            {
                Console.WriteLine(digit);
                break;
            }
        }

    }
}