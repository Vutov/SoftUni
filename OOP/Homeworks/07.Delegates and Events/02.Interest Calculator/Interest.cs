using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Interest_Calculator
{
    delegate double PerformCalculation(int sum, double interest, int years);

    class Interest
    {
        static double GetSimpleInterest(int sum, double interest, int years)
        {
            return sum * (1 + interest * years);
        }

        static double GetCompoundInterest(int sum, double interest, int years)
        {
            var n = 12;
            return sum * Math.Pow((1 + interest / n), years * n);
        }

        static void Main(string[] args)
        {
            PerformCalculation simpleInterestCalc = GetSimpleInterest;
            PerformCalculation compelexInterestCalc = GetCompoundInterest;
            var simpleInterest = new InterestCalculator(2500, 0.072, 15, simpleInterestCalc);
            var complexInterest = new InterestCalculator(500, 0.056, 10, compelexInterestCalc);
            Console.WriteLine(simpleInterest);
            Console.WriteLine(complexInterest);

        }
    }
}
