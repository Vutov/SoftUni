using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class BookOrders
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        decimal totalPrice = 0;
        decimal totalBooks = 0;

        for (int i = 0; i < n; i++)
        {
            decimal booksPerPack = decimal.Parse(Console.ReadLine());
            decimal numOfPacks = decimal.Parse(Console.ReadLine());
            decimal price = decimal.Parse(Console.ReadLine());
            //decimal booksPerPack = 150;
            //decimal numOfPacks = 100;
            //decimal price = 15.9m;
            decimal currentTotalBooks = booksPerPack * numOfPacks;
            decimal discount = 0.05m;

            if (booksPerPack >= 10 && booksPerPack < 110)
            {
                while (booksPerPack - 10 > 9)
                {
                    booksPerPack -= 10;
                    discount += 0.01m;
                }
            }
            else if (booksPerPack >= 110)
            {
                discount = 0.15m;
            }
            else
            {
                discount = 0;
            }
            decimal disountedPrice = price - price * discount;
            totalPrice += currentTotalBooks * disountedPrice;
            totalBooks += currentTotalBooks;
        }
        Console.WriteLine("{0}\n{1:F}", totalBooks, totalPrice);

    }
}
//10, there is no discount. Otherwise they have the following discounts 
//(10-19 packets = 5% discount, 20-29 = 6%, 30-39 = 7%, ..., 100-109 = 14%).
//If the packets are 110 or more, there is 15% discount for all books. 9% 15% 
/*10-19 5
20 - 29 6
30 - 39 7
40 - 49 8
50 - 59 9
60 - 69 10
70 - 79 11
80 - 89 12
90 - 99 13
100 - 109 14*/