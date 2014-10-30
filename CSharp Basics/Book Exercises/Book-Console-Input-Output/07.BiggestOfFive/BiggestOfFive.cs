using System;

class BiggestOfFive
{
    static void Main(string[] args)
    {
        int biggest = new int();
        for (int i = 1; i <= 5; i++)
        {
            Console.WriteLine("Please enter number{0} :", i);
            int number = int.Parse(Console.ReadLine());
            biggest = Math.Max(biggest, number);
        }
        Console.WriteLine("The biggest number is {0}.", biggest);
    }
}

//Напишете програма, която чете пет числа от конзолата и отпечатва най-голямото от тях.