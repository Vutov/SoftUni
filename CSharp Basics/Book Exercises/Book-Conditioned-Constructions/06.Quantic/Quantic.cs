using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.Quantic
{
    class Quantic
    {
        static void Main(string[] args)
        {
        Console.WriteLine("Please enter a:");
        double a = double.Parse(Console.ReadLine());
        Console.WriteLine("Please enter b:");
        double b = double.Parse(Console.ReadLine());
        Console.WriteLine("Please enter c:");
        double c = double.Parse(Console.ReadLine());
        double firstRoot = (-b + Math.Sqrt(Math.Pow(b, 2) - 4 * a * c)) / (2 * a);
        Console.WriteLine(firstRoot);
        double secondRoot = (- b - Math.Sqrt(Math.Pow(b, 2) - 4 * a * c)) / (2 * a);
        Console.WriteLine(secondRoot);
    }
}
