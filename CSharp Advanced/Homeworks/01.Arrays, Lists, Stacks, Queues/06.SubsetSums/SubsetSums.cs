using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class SubsetSums
{
    static void Main(string[] args)
    {
        int neededSum = int.Parse(Console.ReadLine());
        List<int> input = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).Distinct().ToList();

        List<string> allLists = getAllCombinations(input, neededSum);
        foreach (var item in allLists)
        {
            Console.WriteLine("{0} = {1}", item, neededSum);
        }

    }
    private static List<String> getAllCombinations(List<int> list, int neededSum)
    {
        //Used:
        //http://stackoverflow.com/questions/7802822/all-possible-combinations-of-a-list-of-values-in-c-sharp
        List<string> allLists = new List<string>();
        List<int> currList = new List<int>();
        double count = Math.Pow(2, list.Count);
        for (int i = 1; i <= count - 1; i++)
        {
            string str = Convert.ToString(i, 2).PadLeft(list.Count, '0');
            for (int j = 0; j < str.Length; j++)
            {
                if (str[j] == '1')
                {
                    currList.Add(list[j]);
                }
            }
            if (currList.Sum() == neededSum)
            {
                allLists.Add(String.Join(" + ", currList));
            }
            currList.Clear();
        }
        return allLists;
    }
}

