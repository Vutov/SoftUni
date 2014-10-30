using System;
// for easier testing of the code I wrote most of it as Methods and added the
// condition values so you can just check them without the need to enter some
// or all of them manualy ;)
class OddOrEven
{

    private static void numIsOdd(int number)
    {
        bool isOdd = true;
        if (number % 2 == 0)
        {
            isOdd = false;
        }
        Console.WriteLine("Number {0} is odd: {1}.", number, isOdd);
    }

    static void Main(string[] args)
    {
        Console.WriteLine("Please enter a number: ");
        int num = int.Parse(Console.ReadLine());
        numIsOdd(num);
        Console.WriteLine("Condition numbers:");
        numIsOdd(3); //test with condition numbers
        numIsOdd(2);
        numIsOdd(-2);
        numIsOdd(-1);
        numIsOdd(0);
    }
}