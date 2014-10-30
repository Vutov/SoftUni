using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class HayvanNumbers
{

    private static bool hasValidSum(int abc, int def, int ghi, int sum)
    {
        int charSum = 0;
        int[] threeDigits = new int[3];
        threeDigits[0] = abc;
        threeDigits[1] = def;
        threeDigits[2] = ghi;

        for (int i = 0; i < 3; i++)
        {
            int firstNumber = threeDigits[i] / 100;
            int seconNumber = (threeDigits[i] - firstNumber * 100) / 10;
            int thirdNumber = threeDigits[i] % 10;
            //Valid numbers check (5-9);
            if (firstNumber < 5 || seconNumber < 5 || thirdNumber < 5)
            {
                return false;
            }
            charSum += firstNumber + seconNumber + thirdNumber;
        }
        if (charSum == sum)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private static bool hasValidDiff(int abc, int def, int ghi, int diff)
    {
        if ((ghi - def) == (def - abc) && (ghi - def) == diff)
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
        //DateTime start = DateTime.Now;
        int sum = int.Parse(Console.ReadLine());
        int diff = int.Parse(Console.ReadLine());
        int count = 0;
        for (int abc = 555; abc <= 999; abc++)
        {
            for (int def = 555; def <= 999; def++)
            {
                for (int ghi = 555; ghi <= 999; ghi++)
                {
                    if (hasValidDiff(abc, def, ghi, diff) && hasValidSum(abc, def, ghi, sum))
                    {
                        Console.WriteLine("" + abc + def + ghi);
                        count++;
                    }
                }
            }
        }
        if (count == 0)
        {
            Console.WriteLine("No");
        }
        /*DateTime after = DateTime.Now;
        TimeSpan runTime = after - start;
        Console.WriteLine(runTime.Seconds);*/
    }
}
//Hayvan numbers are 9-digit numbers in format abcdefghi, 
//such that their sub-numbers abc, def and ghi have a difference 
//diff (ghi-def = def-abc = diff), their sum of digits is sum and
//abc < def < ghi, where each digit a, b, c, d, e, f, g, h and i is
//in range [5…9].
