namespace LimitedCoins
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class LimitedCoins
    {
        private static readonly HashSet<string> Combinations = new HashSet<string>();

        static void Main(string[] args)
        {
            var s = 100;
            var coins = new int[] { 50, 20, 20, 20, 20, 20, 10 };

            GetAllCombinations(coins.ToArray(), s, new bool[coins.Length], new List<int>());
            Console.WriteLine(Combinations.Count);
        }

        private static void GetAllCombinations(int[] coins, int desiredSum, bool[] usedCoins, List<int> currentElements, int currentSum = 0, int startNum = 0)
        {
            if (currentSum == desiredSum)
            {
                Combinations.Add(string.Join("", currentElements));
                return;
            }

            if (currentSum > desiredSum)
            {
                return;
            }

            for (int i = startNum; i < coins.Length; i++)
            {
                if (usedCoins[i] == false)
                {
                    usedCoins[i] = true;
                    currentElements.Add(coins[i]);
                    currentSum += coins[i];

                    GetAllCombinations(coins, desiredSum, usedCoins, currentElements, currentSum, i);

                    currentSum -= coins[i];
                    currentElements.Remove(coins[i]);
                    usedCoins[i] = false;
                }
            }
        }
    }
}
