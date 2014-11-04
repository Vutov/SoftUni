using System;

class BitShooter
{
    static void Main()
    {
        //ulong number = 4227378815862876842;
        //ulong number = 33860256;
        ulong number = ulong.Parse(Console.ReadLine());

        for (int shoots = 0; shoots < 3; shoots++)
        {
            string input = Console.ReadLine();
            //string input = "22 3";
            int[] coordinates = Array.ConvertAll(input.Split(' '), int.Parse);
            int centre = coordinates[0];
            int size = coordinates[1];
            int halfSize = size / 2;
            int startBit = centre - halfSize;
            int endBit = centre + halfSize;
            //Set bits to 0;
            for (int bit = startBit; bit <= endBit; bit++) //All blasted bits;
            {
                if (bit >= 0 && bit < 64)
                {
                    number = number & ~(1ul << bit);
                }
            }
            //Console.WriteLine(number);
        }
        //Console.WriteLine(number);
        int leftBitsCount = 0;
        int rightBitsCount = 0;
        for (int bit = 0; bit <= 31; bit++)//Right bits;
        {
            ulong currentBit = (number >> bit) & 1;
            if (currentBit == 1)
            {
                rightBitsCount++;
            }
        }
        //Console.WriteLine(rightBitsCount);
        for (int bit = 32; bit <= 63; bit++)
        {
            ulong currentBit = (number >> bit) & 1;
            if (currentBit == 1)
            {
                leftBitsCount++;
            }
        }
        Console.WriteLine("left: {0}\nright: {1}",leftBitsCount, rightBitsCount);

    }
}