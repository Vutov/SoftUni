using System;

class ExchangeIfGreater
{
    static void Main(string[] args)
    {
        float a = float.Parse(Console.ReadLine());
        float b = float.Parse(Console.ReadLine());
        float c;
        if (a > b)
        {
            c = b;
            b = a;
            a = c;
        }
        Console.WriteLine("{0} {1}", a, b);
    }
}

/*Write an if-statement that takes two integer variables
 * a and b and exchanges their values if the first one is
 * greater than the second one. As a result print the values a and b,
 * separated by a space. Examples:
 
a	b	result	   
5	2	2 5	   
3	4	3 4	   
5.5	4.5	4.5 5.5	 
*/