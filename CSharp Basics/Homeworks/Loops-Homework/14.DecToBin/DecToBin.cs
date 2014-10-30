using System;

class DecToBin
{
    static void Main(string[] args)
    {
        long decNumber = long.Parse(Console.ReadLine());
        string binary = "";
        if (decNumber == 0)
        {
            Console.Write(0);
        }
        while (decNumber != 0)
        {
            long digit = decNumber % 2;
            binary += "" + digit;
            decNumber /= 2;
        }
        //Reverse the string to get the proper binary representation;
        int len = binary.Length - 1;
        for (int i = len; i >= 0; i--)
        {
            Console.Write(binary[i]);
        }
        Console.WriteLine();
    }
}