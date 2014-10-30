using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class CountWordInText
{
    private static void CountWords(string word, string text)
    {
        char[] separator = { ' ', '.', '“', '”', '!', ',', '@', '(', ')', '/', '\\' };
        var words = text.ToLower().Split(separator, StringSplitOptions.RemoveEmptyEntries)
            .Where(w => w.StartsWith(word.ToLower()) && w.Length == word.Length);
        int count = words.Count();
        Console.WriteLine(count);
    }
    
    static void Main(string[] args)
    {
        string exampleWord1 = "hi";
        string exampleText1 = "Hidden networks say “Hi” only to Hitachi devices. Hi, said Matuhi. HI!";
        string exampleWord2 = "SoftUni";
        string exampleText2 = "The Software University (SoftUni) trains software engineers, gives them " +
        "a profession and a job. Visit us at http://softuni.bg. Enjoy the SoftUnification at SoftUni.BG. " +
        "Contact us.Email: INFO@SOFTUNI.BG. Facebook: https://www.facebook.com/SoftwareUniversity. YouTube: " +
        "http://www.youtube.com/SoftwareUniversity. Google+: https://plus.google.com/+SoftuniBg/. " + 
        "Twitter: https://twitter.com/softunibg. GitHub: https://github.com/softuni";
        CountWords(exampleWord1, exampleText1);
        CountWords(exampleWord2, exampleText2);
        
        //If you want to test with your input;
        /*string keyWord = Console.ReadLine();
        string input = Console.ReadLine();
        CountWords(keyWord, input);*/
    }
}