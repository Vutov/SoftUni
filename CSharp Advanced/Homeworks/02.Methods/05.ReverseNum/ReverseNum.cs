using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class ReverseNum
{
    private static double GetReversedNumber(double num)
    {
        string revNum = string.Join("", num.ToString().Reverse().ToArray());
        return double.Parse(revNum);
    }
    
    static void Main(string[] args)
    {
        double reversed = GetReversedNumber(double.Parse(Console.ReadLine()));
        Console.WriteLine(reversed);
    }
}

