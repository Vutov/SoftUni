using System;

class QuanticFormula
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

//Напишете програма, която чете коефициентите a, b и c
//от конзолата и решава уравнението: ax2+bx+c=0. Програмата
//трябва да принтира реалните решения на уравнението на конзолата.