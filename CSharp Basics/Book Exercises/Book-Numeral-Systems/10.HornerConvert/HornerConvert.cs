using System;

class HornerConvert
{
    static void Main(string[] args)
    {
        string binary = "1001";
        int len = binary.Length;
        //First two bits from right to left.
        int firstBit = 0;
        int secondBit = 0;
        if (binary[0] == '1')
        {
            firstBit = 1;
        }
        if (binary[1] == '1')
	    {
		    secondBit = 1;
	    }
        int dec = firstBit * 2 + secondBit;
        //Rest of the bits.
        int number = 0;
        for (int i = 2; i < len; i++ )
        {
            if (binary[i] == '1')
            {
                number = 1;
            }
            else
            {
                number = 0;
            }
            dec = (dec * 2) + number;
        }
        Console.WriteLine(dec);
    }
}

//1001(2) = ((1 × 2 + 0) × 2 + 0) × 2 + 1 = 2 × 2 × 2 + 1 = 9