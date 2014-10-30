using System;

class InputReader
{
    static void Main(string[] args)
    {
        Console.WriteLine("Please choose a type:\n1 --> int\n2 --> double\n3 --> string");
        int menu = int.Parse(Console.ReadLine());

        switch (menu)
        {
            case 1:
                Console.WriteLine("Please enter a integer:");
                int number = int.Parse(Console.ReadLine());
                number += 1;
                Console.WriteLine(number);
                break;
            case 2:
                Console.WriteLine("Please enter a double:");
                double doubleNumber = double.Parse(Console.ReadLine());
                doubleNumber += 1;
                Console.WriteLine(doubleNumber);
                break;
            case 3:
                Console.WriteLine("Please enter a string:");
                string str = Console.ReadLine();
                str += "*";
                Console.WriteLine(str);
                break;
            default:
                Console.WriteLine("{0} is not valid input!", menu);
                break;
        }
    }
}