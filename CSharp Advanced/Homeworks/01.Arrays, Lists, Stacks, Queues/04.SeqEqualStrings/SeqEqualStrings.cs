using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class SeqEqualStrings
{
    static void Main(string[] args)
    {
        string[] input = Console.ReadLine().Split(' ');
        int len = input.Length;
        List<string> buffer = new List<string>();
        for (int i = 0; i < len - 1; i++)
        {
            if (input[i].ToLower().CompareTo(input[i + 1].ToLower()) == 0)
            {
                buffer.Add(input[i]);
            }
            else
            {
                buffer.Add(input[i]);
                Console.WriteLine(String.Join(" ", buffer));
                buffer.Clear();
            }
        }
        //Last buffer;
        buffer.Add(input[len - 1]);
        Console.WriteLine(String.Join(" ", buffer));
    }
}
