using System;

class BinToDec
{
    static void Main(string[] args)
    {
        //Using Horner's convertion;
        string binary = Console.ReadLine();
        int len = binary.Length;
        //First two bits from right to left;
        int firstBit = 0;
        int secondBit = 0;
        if (len >= 2)
        {
            if (binary[0] == '1')
            {
                firstBit = 1;
            }
            if (binary[1] == '1')
            {
                secondBit = 1;
            }
            long decNumber = firstBit * 2 + secondBit;
            //Rest of the bits;
            int digit;
            for (int i = 2; i < len; i++)
            {
                if (binary[i] == '1')
                {
                    digit = 1;
                }
                else
                {
                    digit = 0;
                }
                decNumber = (decNumber * 2) + digit;
            }
            Console.WriteLine(decNumber);
        }
        else
        {
            if (binary[0] == '1')
            {
                Console.WriteLine(1);
            }
            else
            {
                Console.WriteLine(0);
            }
        }
    }
}