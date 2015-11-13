namespace Fractional_Knapsack
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    class FractionalKnapsack
    {
        static void Main(string[] args)
        {
            var capacity = int.Parse(Regex.Match(Console.ReadLine(), @".+:\s(\d+)").Groups[1].Value);
            var items = int.Parse(Regex.Match(Console.ReadLine(), @".+:\s(\d+)").Groups[1].Value);
            var pricePerWeight = new Dictionary<double, string>();
            for (int i = 0; i < items; i++)
            {
                var item = Console.ReadLine();
                var data = Regex.Match(item, @"(\d+).+?(\d+)");
                var coef = double.Parse(data.Groups[1].Value) / double.Parse(data.Groups[2].Value);
                pricePerWeight.Add(coef, item);
            }

            var sortedPricePerWeight = pricePerWeight.OrderByDescending(p => p.Key);
            var capacityLeft = capacity;
            var totalPrice = 0d;
            var usedItems = new List<string>();

            foreach (var pair in sortedPricePerWeight)
            {
                var data = Regex.Match(pair.Value, @"(\d+).+?(\d+)");
                var price = int.Parse(data.Groups[1].Value);
                var weight = int.Parse(data.Groups[2].Value);
                if (capacityLeft > weight)
                {
                    totalPrice += price;
                    usedItems.Add("100|" + weight + "|" + price);
                    capacityLeft -= weight;
                }
                else
                {
                    var percentageToUse = (double)capacityLeft / weight;
                    usedItems.Add(string.Format("{0}|", percentageToUse * 100) + weight + "|" + price);
                    totalPrice += price * percentageToUse;
                    break;
                }
            }

            foreach (var item in usedItems)
            {
                var data = item.Split('|');
                var percentage = double.Parse(data[0]);
                var weight = double.Parse(data[1]);
                var price = double.Parse(data[2]);
                Console.WriteLine("Take {0:F2}% of item with price {1:F2} and weight {2:F2}",
                    percentage, price, weight);
            }

            Console.WriteLine("Total price: {0:F2}", totalPrice);
        }
    }
}
