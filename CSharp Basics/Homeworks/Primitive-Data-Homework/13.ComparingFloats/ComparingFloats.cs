using System;

class ComparingFloats
{
    static bool compare(double a, double b) // method witch takes 2 double's and returning boolean
    {
        double eps = 0.000001d;
        double sub;
        sub = Math.Abs(a - b);
        return sub < eps;
    }
    static void Main(string[] args)
    {
        Console.WriteLine("Comparing 5.3 and 6.01. Expected - False");
        Console.WriteLine(compare(5.3, 6.01));
        Console.WriteLine("Comparing 5.00000001 and 5.00000003. Expected - True");
        Console.WriteLine(compare(5.00000001, 5.00000003));
        Console.WriteLine("Comparing 5.00000005 and 5.00000001. Expected - True");
        Console.WriteLine(compare(5.00000005, 5.00000001));
        Console.WriteLine("Comparing -0.0000007 and 0.00000007. Expected - True");
        Console.WriteLine(compare(-0.0000007, 0.00000007));
        Console.WriteLine("Comparing -4.999999 and -4.999998. Expected - False");
        Console.WriteLine(compare(-4.999999, -4.999998));
        Console.WriteLine("Comparing 4.999999 and 4.999998. Expected - False");
        Console.WriteLine(compare(4.999999, 4.999998));
    }
}