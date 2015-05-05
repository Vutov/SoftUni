
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class LongestIncreasingSeq
{
    static void Main(string[] args)
    {
        int[] input = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();
        int len = input.Length;
        List<int> buffer = new List<int>();
        int maxLen = 0;
        string longest = "";
        for (int i = 0; i < len - 1; i++)
        {
            if (input[i] < input[i + 1])
            {
                buffer.Add(input[i]);
            }
            else
            {
                buffer.Add(input[i]);
                if (buffer.Count > maxLen)
                {
                    maxLen = buffer.Count;
                    longest = String.Join(" ", buffer);
                }
                Console.WriteLine(String.Join(" ", buffer));
                buffer.Clear();
            }
        }
        //Last buffer;
        buffer.Add(input[len - 1]);
        if (buffer.Count > maxLen)
        {
            longest = String.Join(" ", buffer);
        }
        Console.WriteLine(String.Join(" ", buffer));
        Console.WriteLine("Longest: {0}", String.Join(" ", longest));
    }
}

