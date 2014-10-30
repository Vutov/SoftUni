using System;

class Words
{
    static void Main(string[] args)
    {
        string word = "aabcdef";
        //string word = Console.ReadLine();
        char[] alphabet = new char[26];
        word.ToLower();
        for (int letter = 97, index = 0; letter <= 122; letter++, index++)
        {
            alphabet[index] = (char)letter;
        }
        foreach (char letter in word)
        {
            for (int i = 0; i < 26; i++)
            {
                if (letter == alphabet[i])
                {
                    Console.Write("{0} ", i);
                }
            }
        }
        Console.WriteLine();
    }
}