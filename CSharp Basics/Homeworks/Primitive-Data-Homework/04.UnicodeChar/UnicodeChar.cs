using System;

class UnicodeChar
{
    static void Main(string[] args)
    {
        char a = '\u002A';
        Console.WriteLine("Desired result: *");
        Console.WriteLine("Actual result: {0}", a);
    }
}