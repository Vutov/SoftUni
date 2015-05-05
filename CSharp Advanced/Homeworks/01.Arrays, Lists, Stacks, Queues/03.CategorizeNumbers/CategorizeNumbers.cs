using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class CategorizeNumbers
{
    static void Main(string[] args)
    {
        List<double> roundNums = new List<double>();
        List<double> notRoundNums = new List<double>();
        Console.ReadLine().Split(' ').Select(x => double.Parse(x)).ToList().ForEach(x =>
        {
            if ((x*10)%10 == 0)
            {
                roundNums.Add(x);
            }
            else
            {
                notRoundNums.Add(x);
            }
        });
        PrintInfo(notRoundNums);
        PrintInfo(roundNums);
        
    }

    private static void PrintInfo(List<double> list)
    {
        Console.WriteLine(
            "[{0}] -> min: {1:F2}, max: {2:F2}, avg: {3:F2}",
            string.Join(", ", list), list.Min(), list.Max(), list.Average()
        );
    } 
}
