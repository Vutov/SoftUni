using System;

class BiggestDeviderOfThoNum
{
    static void Main(string[] args)
    {
        Console.WriteLine("Please enter fist number:");
        int firstNumber = int.Parse(Console.ReadLine());
        Console.WriteLine("Please enter second number:");
        int secondNumber = int.Parse(Console.ReadLine());
        int devider = 2;
        int maxDevider = Math.Min(firstNumber, secondNumber);
        int biggestDevider = 1;
        while (devider <= maxDevider)
        {
            if (firstNumber % devider == 0 && secondNumber % devider == 0)
            {
                if (devider > biggestDevider)
                {
                    biggestDevider = devider;
                }
            }
            devider++;
        }
        Console.WriteLine(biggestDevider);
    }
}

//Напишете програма, която за дадени две числа, намира най-големия им общ делител.