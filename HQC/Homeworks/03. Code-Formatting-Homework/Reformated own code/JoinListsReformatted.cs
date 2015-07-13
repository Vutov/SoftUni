namespace Reformated_own_code
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class JoinListsReformatted
    {
        public static void Main(string[] args)
        {
            string firstIntegers = Console.ReadLine();
            List<string> finalNumbers = firstIntegers.Split(' ').ToList();
            string secondIntegers = Console.ReadLine();
            string[] secondArray = secondIntegers.Split(' ');

            foreach (string number in secondArray)
            {
                if (finalNumbers.IndexOf(number) == -1)
                {
                    finalNumbers.Add(number);
                }
            }

            int len = finalNumbers.Count;
            for (int i = 0; i < len; i++)
            {
                while (finalNumbers.IndexOf(finalNumbers[i]) != finalNumbers.LastIndexOf(finalNumbers[i]))
                {
                    finalNumbers.Remove(finalNumbers[i]);
                    len--;
                }
            }

            // int sorting needed, string sorting does 2, 22, 23, 4, 43, etc.
            List<int> digits = new List<int>();
            foreach (string number in finalNumbers)
            {
                digits.Add(Convert.ToInt32(number));
            }

            digits.Sort();

            foreach (int number in digits)
            {
                Console.Write(number + " ");
            }

            Console.WriteLine();
        }
    }
}