using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Phonebook
{
    static void Main(string[] args)
    {
        string input = Console.ReadLine();
        var book = new Dictionary<string, List<string>>();

        //Fill;
        while (!input.Equals("search"))
        {
            string[] data = input.Split('-');
            if (!book.ContainsKey(data[0]))
            {
                book[data[0]] = new List<string>();
            }

            book[data[0]].Add(data[1]);
            input = Console.ReadLine();
        }

        //Search;
        input = Console.ReadLine();
        while (!input.Equals(""))
        {
            if (book.ContainsKey(input))
            {
                Console.WriteLine("{0} -> {1}", input, string.Join(", ", book[input]));
            }
            else
            {
                Console.WriteLine("Contact {0} does not exist.", input);
            }

            input = Console.ReadLine();
        }
    }
}
