using System;

class ThirdNumber
{
    static void Main(string[] args)
    {
        int number = int.Parse(Console.ReadLine());
        //int number = 735;
        int third = new int();
        for (int i = 0; i < 3; i++)
        {
            third = number % 10;
            number /= 10;
        }
        if (third == 7)
        {
            Console.WriteLine("The third digit is 7.");
        }
        else
        {
            Console.WriteLine("The third digit is NOT 7.");
        }
    }
}