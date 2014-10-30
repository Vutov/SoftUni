using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class RemoveNames
{
    static void Main(string[] args)
    {
        //List<string> firstList = new List<string>{"Peter", "Alex", "Maria", "Todor", "Steve", "Diana", "Steve" };
        //List<string> secondList = new List<string> { "Todor", "Steve", "Nakov" };

        //Read the names and convert to list;
        string startingNames = Console.ReadLine();
        string[] firstArray = startingNames.Split(' ');
        List<string> reducedNames = new List<string>();
        foreach (string name in firstArray)
        {
            reducedNames.Add(name);
        }
        string deductedNames = Console.ReadLine();
        string[] secondArray = deductedNames.Split(' ');
        //Remove the names from second list in first list;
        foreach (string name in secondArray)
        {
            //Ensure all duplicates are removed;
            while (reducedNames.IndexOf(name) > 0)
            {
                reducedNames.Remove(name);
            }
        }
        //Print the remaining names;
        foreach (string name in reducedNames)
        {
            Console.Write(name + " ");
        }
        Console.WriteLine();
    }
}
