using System;

class InputReader
{
    static void Main(string[] args)
    {
        Console.WriteLine("For int enter 1, for double enter 2, for string enter 3");
        int menu = int.Parse(Console.ReadLine());
        if (menu <= 3 && menu > 0)
        {
            Console.WriteLine("Please enter your information");
        }
        switch (menu)
        {
            case 1:
                int number = int.Parse(Console.ReadLine());
                number += 1;
                Console.WriteLine(number);
                break;
            case 2:
                double doubleNumber = double.Parse(Console.ReadLine());
                doubleNumber += 1;
                Console.WriteLine(doubleNumber);
                break;
            case 3:
                string str = Console.ReadLine();
                str += "*";
                Console.WriteLine(str);
                break;
            default:
                Console.WriteLine("{0} is not valid input", menu);
                break;
        }
    }
}

//Напишете програма, която по избор на потребителя прочита от конзолата променлива от тип 
//int, double или string. Ако променливата е int или double, трябва да се увеличи с 1.
//Ако променливата е string, трябва да се прибави накрая символа "*". Отпечатайте получения 
//резултат на конзолата. Използвайте switch конструкция.