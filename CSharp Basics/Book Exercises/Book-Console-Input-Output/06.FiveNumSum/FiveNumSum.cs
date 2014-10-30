using System;

class FiveNumSum
{
    static void Main(string[] args)
    {
        int sum = new int();
        for (int i = 1; i <= 5; i++)
        {
            Console.WriteLine("Please enter number{0} :", i);
            string str = Console.ReadLine();
            int number;
            bool isNumber = Int32.TryParse(str, out number);
            while (isNumber == false)
            {
                Console.WriteLine("{0} is not number, please enter a number.", str);
                str = Console.ReadLine();
                isNumber = Int32.TryParse(str, out number);
            }
            sum += number;
        }
        Console.WriteLine("Sum of the numbers is " + sum);
    }
}
//Напишете програма, която чете пет числа и отпечатва тяхната сума. 
//При невалидно въведено число да се подкани потребителя да въведе друго число.