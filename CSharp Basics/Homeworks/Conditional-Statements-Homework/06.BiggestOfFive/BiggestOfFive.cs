using System;

class BiggestOfFive
{
    static void Main(string[] args)
    {
        float a = float.Parse(Console.ReadLine());
        float b = float.Parse(Console.ReadLine());
        float c = float.Parse(Console.ReadLine());
        float d = float.Parse(Console.ReadLine());
        float e = float.Parse(Console.ReadLine());
        float bigger1 = new float();
        float bigger2 = new float();
        float biggest = new float();

        if (a > b)
        {
            bigger1 = a;
        }
        else
        {
            bigger1 = b;
        }
        if (c > d)
        {
            bigger2 = c;
        }
        else
        {
            bigger2 = d;
        }
        if (bigger1 > bigger2)
        {
            biggest = bigger1;
        }
        else
        {
            biggest = bigger2;
        }
        if (biggest > e)
        {
            Console.WriteLine(biggest);
        }
        else
        {
            Console.WriteLine(e);
        }

    }
}
/*
Write a program that finds the biggest of five numbers by using only five if statements. Examples:
 
a	b	c	d	e	biggest	   
5	2	2	4	1	5	   
-2	-22	1	0	0	1	   
-2	4	3	2	0	4	   
0	-2.5	0	5	5	5	   
-3	-0.5	-1.1	-2	-0.1	-0.1	 
*/