using System;

class Stuff
{
    private static void PrintDigitsBackwards()
    {
        Console.WriteLine("Please enter the number:");
        int number = int.Parse(Console.ReadLine());
        Console.Write("The backwords number is: ");
        while (number != 0)
        {
            int digit = number % 10;
            number /= 10;
            Console.Write(digit);
        }
        Console.WriteLine();
    }

    private static void Avarage()
    {
        Console.WriteLine("How many numbers you will enter?");
        int num = int.Parse(Console.ReadLine());
        if (num == 0)
        {
            Console.WriteLine("No avarage");
            return;
        }
        float sum = 0;
        for (int i = 0; i < num; i++)
        {
            int number = int.Parse(Console.ReadLine());
            sum += number;
        }
        float avarage = sum / num;
        Console.WriteLine("The avarage is " + avarage);
    }

    private static void LinaryEquation()
    {
        Console.WriteLine("Please enter a: ");
        int a = int.Parse(Console.ReadLine());
        Console.WriteLine("Please enter b: ");
        if (a == 0)
        {
            Console.WriteLine("a can't be 0");
            return;
        }
        int b = int.Parse(Console.ReadLine());
        float x = - b / a;
        Console.WriteLine("x is {0}", x);
    }

    static void Main(string[] args)
    {
        Console.WriteLine("1 for backwards digits\n2 for avarage of numbers\n" + 
            "3 for linary equation");
        int menu = int.Parse(Console.ReadLine());
        if (menu == 1)
        {
            PrintDigitsBackwards();
        }
        else if (menu == 2)
        {
            Avarage();
        }
        else if (menu == 3)
        {
            LinaryEquation();
        }
        else
        {
            Console.WriteLine("1 - 3 allowed, {0} is not a valid option!", menu);
        }
    }
}
