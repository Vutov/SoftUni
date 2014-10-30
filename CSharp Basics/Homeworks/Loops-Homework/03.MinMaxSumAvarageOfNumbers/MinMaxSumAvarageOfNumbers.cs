using System;

class MinMaxSumAvarageOfNumbers
{
    static void Main(string[] args)
    {
        Console.WriteLine("How many numbers will be entered?");
        int sequenceLength = int.Parse(Console.ReadLine());
        int sum = new int();
        int min = int.MaxValue;
        int max = int.MinValue;

        for (int i = 0; i < sequenceLength; i++)
        {
            int number = int.Parse(Console.ReadLine());
            if (number < min)
	        {
                min = number;
	        }
            else if (number > max)
            {
                max = number;
            }
            sum += number;
        }
        float avarage = sum / (float) sequenceLength;
        Console.WriteLine("min = {0}\nmax = {1}\nsum = {2}\navg = {3:F}", 
            min, max, sum, avarage);
    }
}

/*Write a program that reads from the console a sequence of n integer
numbers and returns the minimal, the maximal number, the sum and the
average of all numbers (displayed with 2 digits after the decimal point). 
The input starts by the number n (alone in a line) followed by n lines, each
holding an integer number. The output is like in the examples below. Examples:
 
input	output		input	output	   
3
2
5
1	min = 1
max = 5
sum = 8
avg = 2.67	 	2
-1
4	min = -1
max = 4
sum = 3
avg = 1.50	 
*/