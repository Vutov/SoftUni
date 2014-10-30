using System;

class HexToDec
{
    static void Main(string[] args)
    {
        string hexNumber = Console.ReadLine();
        long decNumber = new long();
        int len = hexNumber.Length - 1;
        int power = 0;
        int error = 0;

        for (int i = len; i >= 0; i--)
        {
            int number = 0;
            char digit = hexNumber[i];
            switch (digit)
            {
                case '0': number = 0; ; break;
                case '1': number = 1; ; break;
                case '2': number = 2; ; break;
                case '3': number = 3; ; break;
                case '4': number = 4; ; break;
                case '5': number = 5; ; break;
                case '6': number = 6; ; break;
                case '7': number = 7; ; break;
                case '8': number = 8; ; break;
                case '9': number = 9; ; break;
                case 'A': number = 10; ; break;
                case 'B': number = 11; ; break;
                case 'C': number = 12; ; break;
                case 'D': number = 13; ; break;
                case 'E': number = 14; ; break;
                case 'F': number = 15; ; break;
                default: 
                    Console.WriteLine("{0} is invalid symbol!", digit);
                    error++;
                    break;
            }
            decNumber += (long)Math.Pow(16, power) * number;
            power++;  
        }
        if (error == 0)
        {
            Console.WriteLine(decNumber);
        }
    }
}
