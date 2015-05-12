using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.StringLength
{
    class StringLength
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            try
            {
                text = text.Substring(0, 20);
            }
            catch (ArgumentException)
            {
                int padding = 20 - text.Length;
                text += new string('*', padding);
            }

            Console.WriteLine(text);
        }
    }
}
