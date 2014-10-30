using System;

    class SmallestAndBiggestNumber
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int smallest = Int32.MaxValue;
            int biggest = new int(); 
            for (int i = 1; i <= n; i++)
            {
                int number = int.Parse(Console.ReadLine());
                if (number < smallest)
                {
                    smallest = number;
                }
                else if (number > biggest)
                {
                    biggest = number;
                }
            }
            Console.WriteLine("Smallest number is {0} and the biggest is {1}.", smallest, biggest);
        }
    }