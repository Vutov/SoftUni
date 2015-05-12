using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _04.TextFilter
{
    class TextFilter
    {
        static void Main(string[] args)
        {
            var banList = Regex.Split(Console.ReadLine(), ", ").ToList();
            string text = Console.ReadLine();
            banList.ForEach(x =>
            {
                text = text.Replace(x, new string('*', x.Length));
            });

            Console.WriteLine(text);
        }
    }
}
