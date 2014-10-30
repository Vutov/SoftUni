using System;

class FloatOrDouble
{
    static void Main(string[] args)
    {
        //34.567839023, 12.345, 8923.1234857, 3456.091
        double var1 = 34.567839023d;
        float var2 = 12.345f;
        double var3 = 8923.1234857d;
        float var4 = 3456.091f;
        Console.WriteLine("Desired result: 34.567839023, 12.345, 8923.1234857, 3456.091");
        Console.WriteLine("Actual result: {0}, {1}, {2}, {3}", var1, var2, var3, var4);
    }
}
