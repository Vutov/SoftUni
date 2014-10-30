using System;

class SumOfElement
{
    static void Main(string[] args)
    {
        string n = Console.ReadLine();//numbers as string with spaces.
        string[] splitedNumbers = n.Split(' ');
        int len = splitedNumbers.Length;
        long biggest = long.MinValue;
        long sum = 0;
        for (int i = 0; i < len; i++)
        {
            long number = long.Parse(splitedNumbers[i]);
            sum += number;
            if (biggest < number)
	        {
                biggest = number;
	        }
        }//comparing sum of numbers with biggest to find if they sum to it.
        if (sum == 2 * biggest)
        {
            Console.WriteLine("Yes, sum={0}", biggest);
        }
        else
        {
            Console.WriteLine("No, diff={0}", Math.Abs(sum - 2 * biggest));
        } 
    }
}