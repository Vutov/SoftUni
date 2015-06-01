using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _17.BiggestTableRow
{
    class BiggestTableRow
    {
        static void Main(string[] args)
        {
            var regex = @"<td>.*?<\/td><td>(.*?)<\/td><td>(.*?)<\/td><td>(.*?)<\/td>";
            var maxSum = 0d;
            var bestSumData = new List<string>();


            var line = Console.ReadLine();
            while (!line.Equals("</table>"))
            {
                var matches = Regex.Matches(line, regex);
                foreach (Match match in matches)
                {
                    var sum = 0d;
                    var data = new List<string>
                    {
                        match.Groups[1].ToString(),
                        match.Groups[2].ToString(),
                        match.Groups[3].ToString()
                    };

                    for (int i = 0; i < data.Count; i++)
                    {
                        if (!data[i].Equals("-"))
                        {
                            sum += double.Parse(data[i]);
                        }
                    }

                    if (sum > maxSum)
                    {
                        maxSum = sum;
                        bestSumData = data;
                    }

                    if (maxSum == 0 && bestSumData.Count == 0)
                    {
                        maxSum = sum;
                        bestSumData = data;
                    }
                }

                line = Console.ReadLine();
            }

            bestSumData.RemoveAll(x => x == "-");

            if (maxSum == 0 && bestSumData.Count == 0)
            {
                Console.WriteLine("no data");
            }
            else
            {
                var digits = string.Join(" + ", bestSumData);
                Console.WriteLine("{0} = {1}", maxSum, digits);
            }
        }
    }
}
