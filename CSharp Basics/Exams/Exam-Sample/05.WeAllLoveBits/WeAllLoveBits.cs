using System;

class WeAllLoveBits
{
    static void Main(string[] args)
    {
        int numbers = int.Parse(Console.ReadLine());
        for (int i = 0; i < numbers; i++)
        {
            uint num = uint.Parse(Console.ReadLine());
            string binary = Convert.ToString(num, 2);
            string mirrorBinary = "";
            //Mirror each of the digits;
            foreach (char digit in binary)
            {
                if (digit == '0')
                {
                    mirrorBinary += '1';
                }
                else
                {
                    mirrorBinary += '0';
                }
            }
            //Reverse position;
            int len = binary.Length;
            string reversedBinary = "";
            for (int digit = len - 1; digit >= 0; digit--)
            {
                reversedBinary += binary[digit];
            }
            uint mirrorNum = Convert.ToUInt32(mirrorBinary, 2);
            uint reversedNum = Convert.ToUInt32(reversedBinary, 2);

            //Mitko's algorithm;
            uint mitkosNum = (num ^ mirrorNum) & reversedNum;
            Console.WriteLine(mitkosNum);
        }
        
    }
}