using System;

class ExtractThirdBit
{

    private static int Extractor(int number)
    {
        int bit = (number >> 3) & 1; // using & ability (only 1 and 1 give back 1, else 0).
        return bit;
    }

    private static void PrintExtractor(int number)
    {
        Console.WriteLine("n = {0} has {1} as third bit", number, Extractor(number));
    }   


    static void Main(string[] args)
    {
        Console.WriteLine("Please enter your number: ");
        int number = int.Parse(Console.ReadLine());
        PrintExtractor(number);
        Console.WriteLine("Condition numbers:");
        //test with condition numbers.
        PrintExtractor(5);
        PrintExtractor(0);
        PrintExtractor(15);
        PrintExtractor(5343);
        PrintExtractor(62241);
    }
}