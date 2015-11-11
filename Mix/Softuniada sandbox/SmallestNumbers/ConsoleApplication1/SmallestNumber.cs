namespace ConsoleApplication1
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class SmallestNumber
    {
        private static void Main(string[] args)
        {
            var input = new Input();
            var numbersCalc = new NumbersCalculator();
            var n = input.GetNextNumber();
            var smallestNums = numbersCalc.GetSmallestNumbers(n, input);

            Console.WriteLine(string.Join(Environment.NewLine, smallestNums));
        }
    }

    public class NumbersCalculator
    {
        public ICollection<int> GetSmallestNumbers(int n, Input input)
        {
            var smallestNums = new List<int>();
            var resultNumber = 3;
            if (n < resultNumber)
            {
                resultNumber = n;
            }

            for (int i = 0; i < resultNumber; i++)
            {
                smallestNums.Add(int.MaxValue);
            }

            for (int i = 0; i < n; i++)
            {
                var number = input.GetNextNumber();
                var maxNumber = smallestNums.Max();
                if (number < maxNumber)
                {
                    smallestNums.Remove(maxNumber);
                    smallestNums.Add(number);
                }
            }

            smallestNums.Sort();

            return smallestNums;
        }
    }

    public class Input
    {
        public virtual int GetNextNumber()
        {
            var number = int.Parse(Console.ReadLine());
            return number;
        }
    }
}

