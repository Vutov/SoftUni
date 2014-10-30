using System;

class FibonachiSequence
{
    static void Main(string[] args)
    {
        Console.WriteLine("Please enter the lenght of the Fibonachi sequence:");
        int n = int.Parse(Console.ReadLine());
        ulong firstNumber = 0;
        ulong secondNumber = 1;
        ulong nextNumber = new int();
        Console.Write("0, 1, ");
        for (int i = 1; i <= n; i++)
        {
            nextNumber = firstNumber + secondNumber;
            firstNumber = secondNumber;
            secondNumber = nextNumber;
            if (i == n)
            {
                Console.Write(nextNumber + ". "); 
            }
            else
            {
                Console.Write(nextNumber + ", ");
            }
        }
        Console.WriteLine();
    }
}

//Напишете програма, която чете от конзолата числото N и отпечатва
//сумата на първите N члена от редицата на Фибоначи: 0, 1, 1, 2, 3, 5,
//8, 13, 21, 34, 55, 89, 144, 233, 377