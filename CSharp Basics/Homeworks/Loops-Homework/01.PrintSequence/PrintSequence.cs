using System;

class PrintSequence
{
    static void Main(string[] args)
    {
        int sequenceLength = int.Parse(Console.ReadLine());

        for (int i = 1; i <= sequenceLength; i++)
        {
            Console.Write(i + " ");
        }
        Console.WriteLine();

    }
}