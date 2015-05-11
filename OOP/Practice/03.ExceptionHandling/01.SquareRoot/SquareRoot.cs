using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class SquareRoot
{
    static void Main(string[] args)
    {
        try
        {
            int num = int.Parse(Console.ReadLine());
            if (num < 0)
            {
                throw new FormatException();
            }

            Console.WriteLine(Math.Sqrt(num));
        }
        catch (FormatException)
        {
            Console.Error.WriteLine("Invalid number");
        }
        finally
        {
            Console.WriteLine("Good bye");
        }
        
    }
}
