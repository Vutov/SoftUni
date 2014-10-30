using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class SeqOfKNumbers
{
    static void Main(string[] args)
    {
        //string input = "3 3 3 8 8 2 5 1 7 7 7 4 4 4 4 3 4 4";
        //string input = "1 1 100 1 1";
        //int k = 4;

        string input = Console.ReadLine();
        int k = int.Parse(Console.ReadLine());
        List<string> numbers = input.Split(' ').ToList();
        for (int index = 0; index < numbers.Count - k + 1; index++)
        {
            bool areSame = true;
            for (int i = 0; i < k - 1; i++)
            {
                if (numbers[index + i] != numbers[index + i + 1])
                {
                    areSame = false;
                }
            }
            //Remove;
            if (areSame)
            {
                for (int j = 0; j < k; j++)
                {
                    numbers.RemoveAt(index);
                }
                index--;
            }
        }
        //Print;
        foreach (string digit in numbers)
        {
            Console.Write(digit + " ");
        }
        Console.WriteLine();
    }
}