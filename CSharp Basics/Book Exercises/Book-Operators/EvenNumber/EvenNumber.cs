using System;

    class EvenNumber
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            //int number = 5;
            if (number % 2 == 0)
            {
                Console.WriteLine("The number {0} is even.", number);
            }
            else
            {
                Console.WriteLine("The number {0} is not even.", number);
            }
        }
    }