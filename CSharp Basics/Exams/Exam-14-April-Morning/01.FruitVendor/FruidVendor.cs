using System;

class FruidVendor
{
    static void Main(string[] args)
    {
        string day = Console.ReadLine();
        decimal totalPrice = new decimal();

        for (int i = 0; i < 3; i++)
        {
            decimal quantity = decimal.Parse(Console.ReadLine());
            string product = Console.ReadLine();
            decimal price = new decimal();
            switch (product)
            {
                case "banana":
                    price = 1.80M; break;
                case "cucumber":
                    price = 2.75M; break;
                case "tomato":
                    price = 3.20M; break;
                case "orange":
                    price = 1.60M; break;
                case "apple":
                    price = 0.86M; break;
                default:
                    break;
            }
            if (day == "Friday")
            {
                totalPrice += (quantity * price * 0.9M);
            }
            else if (day == "Sunday")
            {
                totalPrice += (quantity * price * 0.95M);
            }
            else if (day == "Tuesday")
            {
                if (product == "orange" || product == "apple" || product == "banana")
                {
                    totalPrice += (quantity * price * 0.8M);
                }
                else
                {
                    totalPrice += (quantity * price);
                }
            }
            else if (day == "Wednesday")
            {
                if (product == "cucumber" || product == "tomato" )
                {
                    totalPrice += (quantity * price * 0.9M);
                }
                else
                {
                    totalPrice += (quantity * price);
                }
            }
            else if (day == "Thursday")
            {
                if (product == "banana")
                {
                    totalPrice += (quantity * price * 0.7M);
                }
                else
                {
                    totalPrice += (quantity * price);
                }
            }
            else
            {
                totalPrice += (quantity * price);
            }
        }
        Console.WriteLine("{0:F}", totalPrice);
    }
}

/*
The local fruit market offers fruits and vegetables with the following standard price list:
banana  1.80
cucumber  2.75
tomato  3.20
orange  1.60
apple  0.86	The market owner decided to introduce the following discounts:
Friday  10% off for all products
Sunday  5% off for all products
Tuesday  20% off for fruits
Wednesday  10% off for vegetables
Thursday  30% off for bananas	 
*/