using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.SqlServer.Server;

namespace _07.LettersChangeNumbers
{
    class LettersChangeNumbers
    {
        static void Main(string[] args)
        {
            var input = Regex.Split(Console.ReadLine(), @"\s+").ToList();

            double sum = 0;
            input.ForEach(line =>
            {
                if (line != "")
                {
                    char leftCh = line[0];
                    char rightCh = line[line.Length - 1];
                    double number = double.Parse(Regex.Match(line, @"(\d+)").Groups[1].ToString());
                    if (leftCh >= 'a' && leftCh <= 'z')
                    {
                        number = number * (leftCh + 1 - 'a');
                    }
                    else
                    {
                        number = number / (leftCh + 1 - 'A');
                    }

                    if (rightCh >= 'a' && rightCh <= 'z')
                    {
                        number = number + (rightCh + 1 - 'a');
                    }
                    else
                    {
                        number = number - (rightCh + 1 - 'A');
                    }

                    sum += number;
                }
            });

            Console.WriteLine("{0:f}", sum);
        }
    }
}
