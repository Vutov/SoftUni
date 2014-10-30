using System;

class CheckThirdBit
{
    static void Main(string[] args)
    {
        int number = int.Parse(Console.ReadLine());
        int eight = 8;
        //int number = 4;
        int num = eight & number;
        if (num != 0)
        {
            Console.WriteLine("The third bit in {0} is 1.", number);
        }
        else
        {
            Console.WriteLine("The third bit in {0} is 0.", number);
        }
    }
}