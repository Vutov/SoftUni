using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class MagicNums
{

    private static bool allowedNumber(int num) // tries every number for not allowed
    {                           // numbers - 0, 8 or 9 -> 105 will not pass.
        string numbers = num.ToString();
        foreach (var item in numbers)
        {
            if (item < '1' || item > '7')
            {
                return false;
            }
        }
        return true;
    }

    private static bool areAllowed(int num1, int num2, int num3) // tests all 3 numbes
    {
        if ((allowedNumber(num1) && allowedNumber(num2) && allowedNumber(num3) == true))
        {    
            return true;
        }
        else
	    {
            return false;
	    }
    }

    private static int calcSum(int num) // calcolates the sum of the 3 numbers inside
    {                           // 125 -> 1 + 2 + 5 = 8.
        int sum = 0;
        while (num > 0)
        {
            sum += num % 10;
            num /= 10;
        }
        return sum;
    }

    private static bool hasEqualSum(int num1, int num2, int num3, int sum)
    {   // checks the if the sum matches
        if (calcSum(num1) + calcSum(num2) + calcSum(num3) == sum)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    static void Main(string[] args)
    {
        int sum = int.Parse(Console.ReadLine());
        int diff = int.Parse(Console.ReadLine());
        int resultsCount = 0; // count in case there are none magic numbers.
        for (int num1 = 111; num1 <= 777; num1++) // tries all numbers from 111 to 777.
        {
            int num2 = num1 + diff; // uses "(ghi-def = def-abc = diff)"
            int num3 = num2 + diff; // to detirmine next suitable numbers.
            if (areAllowed(num1, num2, num3) && hasEqualSum(num1, num2, num3, sum) && num3 <= 777) 
            {
                Console.WriteLine(num1 + "" + num2 + "" + num3);
                resultsCount++;
            }
        }
        if (resultsCount == 0)
        {
            Console.WriteLine("No");
        }
    }
}