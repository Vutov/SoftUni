using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class JoinLists
{
    static void Main(string[] args)
    {
        //Read the numbers and convert to list;
        string firstIntegers = Console.ReadLine();
        string[] firstArray = firstIntegers.Split(' ');
        List<string> finalNumbers = new List<string>();
        foreach (string number in firstArray)
        {
            finalNumbers.Add(number);
        }
        string secondIntegers = Console.ReadLine();
        string[] secondArray = secondIntegers.Split(' ');
        //Join the lists;
        foreach (string number in secondArray)
        {
            if (finalNumbers.IndexOf(number) == -1)
            {
                finalNumbers.Add(number);
            }
        }
        //Remove duplicates;
        int len = finalNumbers.Count;
        for (int i = 0; i < len; i++)
        {
            while (finalNumbers.IndexOf(finalNumbers[i]) != finalNumbers.LastIndexOf(finalNumbers[i]))
            {
                finalNumbers.Remove(finalNumbers[i]);
                len--;
            }
        }
        //Sort;
        List<int> digits = new List<int>();//int sorting needed, string sorting does 2, 22, 23, 4, 43, ect;
        foreach (string number in finalNumbers)
        {
            digits.Add(Convert.ToInt32(number));
        }
        digits.Sort();
        //Print;
        foreach (int number in digits)
        {
            Console.Write(number + " ");
        }
        Console.WriteLine();
    }
}