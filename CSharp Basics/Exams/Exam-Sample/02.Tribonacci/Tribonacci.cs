using System;
using System.Numerics;

class Tribonacci
{
    static void Main(string[] args)
    {
        BigInteger firstNum = BigInteger.Parse(Console.ReadLine());
        BigInteger secondNum = BigInteger.Parse(Console.ReadLine());
        BigInteger thirdNum = BigInteger.Parse(Console.ReadLine());
        int len = int.Parse(Console.ReadLine());
        BigInteger nextNum = firstNum + secondNum + thirdNum;

        for (int i = 1; i < len - 3; i++)
        {
            firstNum = secondNum;
            secondNum = thirdNum;
            thirdNum = nextNum;
            nextNum = firstNum + secondNum + thirdNum;
        }
        if (len == 1)
        {
            Console.WriteLine(firstNum);
        }
        else if (len == 2)
	    {
            Console.WriteLine(secondNum);
	    }
        else if (len == 3)
        {
            Console.WriteLine(thirdNum);
        }
        else
        {
            Console.WriteLine(nextNum);
        }
        
    }
}