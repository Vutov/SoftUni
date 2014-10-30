using System;

class ZeroSubset
{
    static void Main(string[] args)
    {
        int num1 = int.Parse(Console.ReadLine());
        int num2 = int.Parse(Console.ReadLine());
        int num3 = int.Parse(Console.ReadLine());
        int num4 = int.Parse(Console.ReadLine());
        int num5 = int.Parse(Console.ReadLine());
        int sum = num1 + num2 + num3 + num4 + num5;
        int failSafe = 0;
        if (sum == 0)
        {
            Console.WriteLine("{0} + {1} + {2} + {3} + {4} = 0",
                num1, num2, num3, num4, num5);
            failSafe++;
        }
        if (sum - num1 == 0)
        {
            Console.WriteLine("{0} + {1} + {2} + {3} = 0",
                num2, num3, num4, num5);
            failSafe++;
        }
        if (sum - num2 == 0)
        {
            Console.WriteLine("{0} + {1} + {2} + {3} = 0",
                num1, num3, num4, num5);
            failSafe++;
        }
        if (sum - num3 == 0)
        {
            Console.WriteLine("{0} + {1} + {2} + {3} = 0",
                num1, num2, num4, num5);
            failSafe++;
        }
        if (sum - num4 == 0)
        {
            Console.WriteLine("{0} + {1} + {2} + {3} = 0",
                num1, num2, num3, num5);
            failSafe++;
        }
        if (sum - num5 == 0)
        {
            Console.WriteLine("{0} + {1} + {2} + {3} = 0",
                num1, num2, num3, num4);
            failSafe++;
        }
        if (sum - num1 - num2 == 0)
        {
            Console.WriteLine("{0} + {1} + {2} = 0",
                num3, num4, num5);
            failSafe++;
        }
        if (sum - num1 - num3 == 0)
        {
            Console.WriteLine("{0} + {1} + {2} = 0",
                num2, num4, num5);
            failSafe++;
        }
        if (sum - num1 - num4 == 0)
        {
            Console.WriteLine("{0} + {1} + {2} = 0",
                num2, num3, num5);
            failSafe++;
        }
        if (sum - num1 - num5 == 0)
        {
            Console.WriteLine("{0} + {1} + {2} = 0",
                num2, num3, num4);
            failSafe++;
        }
        if (sum - num2 - num3 == 0)
        {
            Console.WriteLine("{0} + {1} + {2} = 0",
                num1, num4, num5);
            failSafe++;
        }
        if (sum - num2 - num4 == 0)
        {
            Console.WriteLine("{0} + {1} + {2} = 0",
                num1, num3, num5);
            failSafe++;
        }
        if (sum - num2 - num5 == 0)
        {
            Console.WriteLine("{0} + {1} + {2} = 0",
                num1, num3, num4);
            failSafe++;
        }
        if (sum - num3 - num4 == 0)
        {
            Console.WriteLine("{0} + {1} + {2} = 0",
                num1, num2, num5);
            failSafe++;
        }
        if (sum - num3 - num5 == 0)
        {
            Console.WriteLine("{0} + {1} + {2} = 0",
                num1, num2, num4);
            failSafe++;
        }
        if (sum - num4 - num5 == 0)
        {
            Console.WriteLine("{0} + {1} + {2} = 0",
                num1, num2, num3);
            failSafe++;
        }
        if (num1 + num2 == 0)
        {
            Console.WriteLine("{0} + {1} = 0",
                num1, num2);
            failSafe++;
        }
        if (num1 + num3 == 0)
        {
            Console.WriteLine("{0} + {1} = 0",
                num1, num3);
            failSafe++;
        }
        if (num1 + num4 == 0)
        {
            Console.WriteLine("{0} + {1} = 0",
                num1, num4);
            failSafe++;
        }
        if (num1 + num5 == 0)
        {
            Console.WriteLine("{0} + {1} = 0",
                num1, num5);
            failSafe++;
        }
        if (num2 + num3 == 0)
        {
            Console.WriteLine("{0} + {1} = 0",
                num2, num3);
            failSafe++;
        }
        if (num2 + num4 == 0)
        {
            Console.WriteLine("{0} + {1} = 0",
                num2, num4);
            failSafe++;
        }
        if (num2 + num5 == 0)
        {
            Console.WriteLine("{0} + {1} = 0",
                num2, num5);
            failSafe++;
        }
        if (num3 + num4 == 0)
        {
            Console.WriteLine("{0} + {1} = 0",
                num3, num4);
            failSafe++;
        }
        if (num4 + num5 == 0)
        {
            Console.WriteLine("{0} + {1} = 0",
                num4, num5);
            failSafe++;
        }
        if (failSafe == 0)
        {
            Console.WriteLine("no zero subset");
        }
    }
}
/*We are given 5 integer numbers. Write a program that finds all subsets of these
 * numbers whose sum is 0. Assume that repeating the same subset several times is
 * not a problem. Examples:
 
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
*/