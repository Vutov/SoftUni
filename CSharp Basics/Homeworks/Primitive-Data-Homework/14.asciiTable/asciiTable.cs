using System;

class asciiTable
{
    static void Main(string[] args)
    {
        for (int i = 0; i <= 255; i++)
        {
            Console.WriteLine("{0} is {1}", i, (char)i /*Convert.ToChar(i)*/);
        }
    }
}