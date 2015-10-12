namespace _01.Binomial
{
    using System;
    using System.Collections.Generic;

    class BinomialCoef
    {
        static void Main(string[] args)
        {
            var n = 10;
            var k = 5;
            var coef = new List<List<int>>
            {
                new List<int>() {1},
                new List<int>() {1, 1, 0}
            };

            for (int row = 2; row <= n; row++)
            {
                coef.Add(new List<int>() { 1 });
                for (int col = 1; col <= row; col++)
                {
                    var num = coef[row - 1][col - 1] + coef[row - 1][col];
                    coef[row].Add(num);
                }

                coef[row].Add(0);
            }

            Console.WriteLine(coef[n][k]);
        }
    }
}
