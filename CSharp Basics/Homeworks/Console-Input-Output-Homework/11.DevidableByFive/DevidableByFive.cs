using System;

class DevidableByFive
{
    static void Main(string[] args)
    {
        Console.WriteLine("Please enter the start number:");
        int startNumber = int.Parse(Console.ReadLine());
        Console.WriteLine("Please enter the end number:");
        int endNumber = int.Parse(Console.ReadLine());
        int count = 0;
        for (int i = startNumber; i <= endNumber; i++)
        {
            if (i % 5 == 0)
            {
                count++;
            }
        }
        Console.WriteLine("In range ({0}, {1}) {2} numbers can be devided by 5"
            + " without remainder.", startNumber, endNumber, count);
    }
}