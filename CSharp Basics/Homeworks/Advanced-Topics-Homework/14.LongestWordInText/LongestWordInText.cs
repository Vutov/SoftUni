using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class LongestWordInText
{
    static void Main(string[] args)
    {
        string input = Console.ReadLine();
        //string input = "Welcome to the Software University.";
        char[] charSeparators = {' ', '.', ','};
        string[] words = input.Split(charSeparators, StringSplitOptions.RemoveEmptyEntries);
        int longestWordLen = 0;
        string longestWord = "";
        foreach (string word in words)
        {
            int currentWordLen = word.Length;
            if (currentWordLen > longestWordLen)
            {
                longestWordLen = currentWordLen;
                longestWord = word;
            }
        }
        Console.WriteLine(longestWord);

    }
}
