using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTMLDispatcher
{
    class Tests
    {
        static void Main(string[] args)
        {
            ElementBuilder div = new ElementBuilder("div");
            div.AddAttribute("id", "page");
            div.AddAttribute("class", "big");
            div.AddContent("<p>Hello</p>");
            Console.WriteLine(div * 2);
            Console.WriteLine(HTMLDispatcher.CreateImage("abv.bg", "abv"));
            Console.WriteLine(HTMLDispatcher.CreateUrl("abv.bg", "abv", "go to abv"));
            Console.WriteLine(HTMLDispatcher.CreateInput());
        }
    }
}
