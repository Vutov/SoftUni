using System;

class NullVal
{
    static void Main(string[] args)
    {
        int? a = null;
        double? b = null;
        Console.WriteLine("integer: {0}\ndouble: {1}", a, b);
        a += null;
        b += 0.63;
        Console.WriteLine("After accumulation:\ninteger: {0}\ndouble: {1}", a, b);
    }
}