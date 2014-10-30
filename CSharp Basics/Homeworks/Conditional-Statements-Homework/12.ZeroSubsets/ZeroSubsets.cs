using System;

class ZeroSubsets
{
    static void Main(string[] args)
    {
        string input = Console.ReadLine();
        string[] digits = input.Split(' ');
        int len = digits.Length;
        int[] numbers = new int[len];
        for (int l = 0; l < len; l++)
		{
            numbers[l] = int.Parse(digits[l]);    	 
		}
        int zeroSum = 0;
        int currentSum = 0;
        int failSafe = 0;
        for (int i = 0; i < len; i++)
        {
            for (int j = i; j < len; j++)
            {
                currentSum += numbers[j];
                if (currentSum == zeroSum)
                {
                    failSafe++;
                    for (int zeroNums = i; zeroNums <= j; zeroNums++)
                    {
                        if (zeroNums < j)
                        {
                            Console.Write("{0} + ", numbers[zeroNums]);
                        }
                        else //last one, don't need "+".
                        {
                            Console.Write("{0} ", numbers[zeroNums]);
                        }
                    }
                    Console.WriteLine("= 0");
                }
            }
            currentSum = 0;
        }
        if (failSafe == 0)
        {
            Console.WriteLine("no zero subset");    
        }
    }
}
/*
We are given 5 integer numbers. Write a program that finds all
 * subsets of these numbers whose sum is 0. Assume that repeating
 * the same subset several times is not a problem. Examples:
 
numbers	result	   
3  -2  1  1 8	-2 + 1 + 1 = 0	   
3 1 -7 35 22	no zero subset	   
1 3 -4 -2 -1	1 + -1 = 0
1 + 3 + -4 = 0
3 + -2 + -1 = 0	   
1 1 1 -1 -1	1 + -1 = 0
1 + 1 + -1 + -1 = 0
1 + -1 + 1 + -1 = 0
…	   
0 0 0 0 0	0 + 0 + 0 + 0 + 0 = 0	 
Hint: you may check for zero each of the 32 subsets with 32 if statements.
*/