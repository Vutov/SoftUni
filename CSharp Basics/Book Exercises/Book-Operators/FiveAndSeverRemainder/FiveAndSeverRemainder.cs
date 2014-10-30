using System;

class FiveAndSeverRemainder
{
    static void Main(string[] args)
    {
        int number = int.Parse(Console.ReadLine());
        //int number = 35;
        if (number % 5 == 0 && number % 7 == 0)
        {
            Console.WriteLine("The number {0} can be divided by 5 and 7 with no remainder.", number);
        }
        else
        {
            Console.WriteLine("The number {0} can't be divided by 5 and 7 with no remainder.", number);
        }
    }
}