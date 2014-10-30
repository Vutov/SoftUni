using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class AverageLoadTimeCalculator
{
    static void Main(string[] args)
    {
        string input =
@"2014-Apr-01 02:01 http://softuni.bg 8.37725
2014-Apr-01 02:05 http://www.nakov.com 11.622
2014-Apr-01 02:06 http://softuni.bg 4.33
2014-Apr-01 02:11 http://www.google.com 1.94
2014-Apr-01 02:11 http://www.google.com 2.011
2014-Apr-01 02:12 http://www.google.com 4.882
2014-Apr-01 02:34 http://softuni.bg 4.885
2014-Apr-01 02:36 http://www.nakov.com 10.74
2014-Apr-01 02:36 http://www.nakov.com 11.75
2014-Apr-01 02:38 http://softuni.bg 3.886
2014-Apr-01 02:44 http://www.google.com 1.04
2014-Apr-01 02:48 http://www.google.com 1.4555
2014-Apr-01 02:55 http://www.google.com 1.977";
        /*string input =
@"2014-Mar-02 11:33 http://softuni.bg 8.37725
2014-Mar-02 11:34 http://www.google.com 1.335
2014-Mar-03 21:03 http://softuni.bg 7.25
2014-Mar-03 22:00 http://www.google.com 2.44
2014-Mar-03 22:01 http://www.google.com 2.45
2014-Mar-03 22:01 http://www.google.com 2.77"*/;

        input += "\r\n"; //for the index to find last row.
        Console.WriteLine("Input data: \n" + input);

        /*Using 2 dictionaries - one for total ms and one for number of
        times the site has been incountered. It can be done with list inside 
        one dictionary as well;*/
        Dictionary<string, double> data = new Dictionary<string, double>();
        Dictionary<string, int> count = new Dictionary<string, int>();

        //Reads row by row and adds to dictionary site name, ms and count;
        int startIndex = input.IndexOf("http://");
        int endOfRow = input.IndexOf("\r");// \r\n ect
        while (true)
        {
            int len = endOfRow - startIndex;
            if (len > 0)
            {
                string siteAndTime = input.Substring(startIndex, len);
                string[] array = siteAndTime.Split(' ');
                double time = Convert.ToDouble(array[1], CultureInfo.InvariantCulture);
                double value;
                if (data.TryGetValue(array[0], out value))//Than count dict has it as well;
                {
                    data[array[0]] += time;
                    count[array[0]] += 1;
                }
                else
                {
                    data.Add(array[0], time);
                    count.Add(array[0], 1);
                }
            }
            else //Last row has been reached and processed;
            {
                break;
            }
            startIndex = input.IndexOf("http://", startIndex + 1);
            endOfRow = input.IndexOf("\r", endOfRow + 1);
        }
        //Result; using both dictionaries: deviding total ms by count;
        foreach (var entry in data)
        {
            Console.WriteLine("{0} -> {1}", entry.Key, entry.Value / count[entry.Key]);
        }

    }
}