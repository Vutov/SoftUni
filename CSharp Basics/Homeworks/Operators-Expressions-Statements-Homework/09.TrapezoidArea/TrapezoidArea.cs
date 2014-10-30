using System;

class TrapezoidArea
{

    private static double Area(double a, double b, double h)
    {
        double area = ((a + b) / 2) * h;
        return area;
    }

    private static void PrintArea(double a, double b, double h)
    {
        Console.WriteLine("The area of this trapezoid is {0}.", Area(a, b, h));
    }

    static void Main(string[] args)
    {
        Console.WriteLine("Enter the first side:");
        double a = double.Parse(Console.ReadLine());
        Console.WriteLine("Enter the second side:");
        double b = double.Parse(Console.ReadLine());
        Console.WriteLine("Enter the height:");
        double h = double.Parse(Console.ReadLine());
        PrintArea(a, b, h);
        Console.WriteLine("Condition numbers:");
        PrintArea(5, 7, 12); //test with condition numbers.
        PrintArea(2, 1, 33);
        PrintArea(8.5, 4.3, 2.7);
        PrintArea(100, 200, 300);
        PrintArea(0.222, 0.333, 0.555);
    }
}

 
//5	7	12	72	 	   
//2	1	33	49.5	 	   
//8.5	4.3	2.7	17.28	 	   
//100	200	300	45000	 	   
//0.222	0.333	0.555	0.1540125	 	 
