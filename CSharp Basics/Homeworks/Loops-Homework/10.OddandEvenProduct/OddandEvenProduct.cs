using System;

class OddandEvenProduct
{
    static void Main(string[] args)
    {
        string n = Console.ReadLine();
        string[] digits = n.Split(' ');
        int oddProduct = 1;
        int evenProduct = 1;
        int len = digits.Length;

        for (int i = 1; i <= len; i++) // 0 % 2 is 0, considered even, so starting from 1;
        {
            if (i % 2 == 0) //Even
            {
                int number = int.Parse(digits[i - 1]);
                evenProduct *= number;
            }
            else //Odd
            {
                int number = int.Parse(digits[i - 1]);
                oddProduct *= number;
            }
        }
        if (evenProduct == oddProduct)
        {
            Console.WriteLine("yes\nproduct = {0}", evenProduct);
        }
        else
        {
            Console.WriteLine("no\nodd_product = {0}\neven_product = {1}",
                oddProduct, evenProduct);
        }

    }
}
/*
You are given n integers (given in a single line, separated by a space).
 * Write a program that checks whether the product of the odd elements is
 * equal to the product of the even elements. Elements are counted from 1
 * to n, so the first element is odd, the second is even, etc. Examples:
 
numbers	result	   
2 1 1 6 3	yes
product = 6	   
3 10 4 6 5 1	yes
product = 60	   
4 3 2 5 2	no
odd_product = 16
even_product = 15	 
*/