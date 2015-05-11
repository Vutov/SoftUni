using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

class EnterNumbers
{

    private static int ReadNumber(int min, int max)
    {
        int number = 0;
        bool validNumber = false;
        while (!validNumber)
        {
            try
            {
                Console.WriteLine("Enter number in range ({0}, {1})", min, max);
                number = int.Parse(Console.ReadLine());
                validNumber = true;

                if (number < min || number > max)
                {
                    throw new FormatException(string.Format("Input cannot be below {0}, or above {1}.", min, max));
                }
            }
            catch (FormatException ex)
            {
                Console.WriteLine("{0} Please enter new number in range ({1}, {2})",
                     ex.Message, min, max);
                validNumber = false;
            }
        }

        Console.WriteLine("{0} is correct number!", number);
        return number;
    }

    static void Main(string[] args)
    {
        var selectedNumbers = new List<int>();
        int min = 1;
        const int max = 100;
        for (int i = 0; i < 10; i++)
        {
            if (selectedNumbers.Count >= 1)
            {
                min = selectedNumbers.Max();
            }

            int number = ReadNumber(min, max);
            selectedNumbers.Add(number);
        }

        Console.WriteLine("Your numbers are:");
        foreach (var number in selectedNumbers)
        {
            Console.WriteLine(number);
        }
    }
}
