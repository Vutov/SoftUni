using System;

class PositiveOrNegative
{
    static void Main(string[] args)
    {
        int[] numbers = new int[3];
        for (int i = 0; i < 3; i++)
        {
            Console.WriteLine("Please enter number{0}:", i + 1);
            numbers[i] = int.Parse(Console.ReadLine());
        }
        int count = new int();//counting number > 0
        foreach (int number in numbers)
        {
            if (number == 0)
            {
                Console.WriteLine("zero");
                break;
            }
            else if (number < 0)
            {
                count++;                 
            }
        }
        if (count == 0 || count == 2) 
        {
            Console.WriteLine("+");
        }
        else // count = 1 or 3.
        {
            Console.WriteLine("-");
        }
    }
}