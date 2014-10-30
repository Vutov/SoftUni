using System;

class IsThirdDigitSeven
{

    private static bool IsSeven(int number)
    {
        bool isSeven = false;
        int third = new int();
        for (int i = 0; i < 3; i++) //no matter the lengh of the number
        { //if it is below 3 digits, the result will be 0, if more than 3
          // the result will be exactly the 3rd number.
            third = number % 10;
            number /= 10;
        }
        if (third == 7)
        {
            isSeven = true;
        }
        return isSeven;
    }

    private static void PrintIsSeven(int number)
    {
        Console.WriteLine("The third digit of {0} is 7: {1}", number, IsSeven(number));
    }

    static void Main(string[] args)
    {
        int number = int.Parse(Console.ReadLine());
        PrintIsSeven(number);
        Console.WriteLine("Condition numbers:");
        PrintIsSeven(5); //test with condition numbers.
        PrintIsSeven(701);
        PrintIsSeven(9703);
        PrintIsSeven(877);
        PrintIsSeven(777877);
        PrintIsSeven(9999799);
    }
}