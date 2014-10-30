using System;

class FibonachiLine
{
    static void Main(string[] args)
    {
        ulong firstNumber = 0;
        ulong secondNumber = 1;
        ulong nextNumber = new int();
        Console.Write("0, 1, ");
        for (int i = 0; i < 100; i++)
        {
            nextNumber = firstNumber + secondNumber;
            firstNumber = secondNumber;
            secondNumber = nextNumber;
            Console.Write(nextNumber + ", ");
            if (i == 100)
            {
                nextNumber = firstNumber + secondNumber;
                firstNumber = secondNumber;
                secondNumber = nextNumber;
                Console.Write(nextNumber + ".\n");
            }
        }
    }
}