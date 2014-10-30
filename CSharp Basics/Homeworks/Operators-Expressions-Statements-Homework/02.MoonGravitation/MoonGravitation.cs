using System;

class MoonGravitation
{

    private static void MoonWeight(double weight)
    {
        double weightOnMoon = 0.17 * weight;
        Console.WriteLine("{0} kg on the moon are: {1} kg", weight, weightOnMoon);
    }

    static void Main(string[] args)
    {
        Console.WriteLine("Please enter your weight(format \"10,0\", not \"10.0\".)");
        double weight = double.Parse(Console.ReadLine()); // NOTE 
        MoonWeight(weight);// you must use " , " when entering the value
                          // from the console - 74,6 - not 74.4 !
        Console.WriteLine("Condition numbers:");
        MoonWeight(86); //test with condition numbers
        MoonWeight(74.6);
        MoonWeight(53.7);
    }
}