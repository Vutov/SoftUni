using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Interest_Calculator
{
    class InterestCalculator
    {
        public InterestCalculator(int sum, double interest, int years, PerformCalculation calc)
        {
            this.Sum = calc(sum, interest, years);
        }

        public double Sum { get; set; }

        public override string ToString()
        {
            return this.Sum.ToString("F4");
        }
    }
}
