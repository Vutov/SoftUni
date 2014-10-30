using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class LongestAreaInArray
{
    static void Main(string[] args)
    {
        int len = int.Parse(Console.ReadLine());
        //Set array;
        string[] words = new string[len];
        for (int i = 0; i < len; i++)
        {
            string text = Console.ReadLine();
            words[i] = text;
        }
        //Find longest area;
        int count = 1;
        int savedCount = 0;
        string word = "";
        string savedWord = "";
        for (int i = 0; i < len - 1; i++)
        {
            if (words[i] == words[i + 1])
            {
                word = words[i];
                count++;
            }
            else
            {
                if (count > savedCount)
                {
                    savedCount = count;
                    savedWord = words[i];
                }
                count = 1;
            }
        }
        //Current count is bigger than saved;
        if (count > savedCount)
        {
            savedCount = count;
            savedWord = word;
        }
        //Result;
        if (len == 0)
        {
            Console.WriteLine(0);
            return;
        }
        else
        {
            Console.WriteLine(savedCount);
        }
        if (len == 1)
        {
            Console.WriteLine(words[0]);
        }
        else
        {
            for (int i = 0; i < savedCount; i++)
            {
                Console.WriteLine(savedWord);
            }
        }

    }
}
