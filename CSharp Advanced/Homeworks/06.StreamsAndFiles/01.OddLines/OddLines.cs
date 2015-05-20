using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.OddLines
{
    class OddLines
    {
        static void Main(string[] args)
        {
            using (var reader = new StreamReader("../../OddLines.cs"))
            {
                int rowCounter = 0;
                var line = reader.ReadLine();
                while (line != null)
                {
                    if (rowCounter % 2 != 0)
                    {
                        Console.WriteLine("{0,3}. {1}", rowCounter, line);
                    }

                    rowCounter++;
                    line = reader.ReadLine();
                }
            }
        }
    }
}