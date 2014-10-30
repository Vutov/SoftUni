using System;

class ExtractIntegerBit
{
    private static int Extractor(int number, int position)
    {
        int bit = (number >> position) & 1;
        return bit;
    }

    private static void PrintExtractor(int number, int position)
    {
        Console.WriteLine("n = {0} has {1} as {2} bit", number, Extractor(number, position), position);
    }   


    static void Main(string[] args)
    {
        Console.WriteLine("Please enter your number: ");
        int number = int.Parse(Console.ReadLine());
        Console.WriteLine("Please enter the position of the bite");
        int position = int.Parse(Console.ReadLine());
        PrintExtractor(number, position);
        Console.WriteLine("Condition numbers:");
        //test with condition numbers.
        PrintExtractor(5, 2);
        PrintExtractor(0, 9);
        PrintExtractor(15, 1);
        PrintExtractor(5343, 7);
        PrintExtractor(62241, 11);
    }
}