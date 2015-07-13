namespace _01.Reverse_numbers_with_stack
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ReverseNumbers
    {
        public static void Main(string[] args)
        {
            var input = Console.ReadLine();
            try
            {
                var intNumbers = input.Split(' ').Select(int.Parse).ToList();
                var stackNumbers = new Stack<int>();
                intNumbers.ForEach(n => stackNumbers.Push(n));
                foreach (var stackNumber in stackNumbers)
                {
                    Console.Write(stackNumber + " ");
                }
            }
            catch (FormatException)
            {
                Console.WriteLine(input);
            }
        }
    }
}
